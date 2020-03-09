using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Amazon.SQS;
using Amazon.SQS.Model;
using Backend.Domain.Core.Bus;
using Backend.Domain.Core.Commands;
using Backend.Domain.Core.Results;
using Backend.Domain.Models.CartModel.Repositories;
using Backend.Domain.Models.InvoiceModel;
using Backend.Domain.Models.ProductModel.Repositories;
using Backend.Shared.Constants;
using Backend.Shared.Utilities;
using Serilog;

namespace Backend.Domain.Models.CartModel.Commands
{
    public sealed class CartCheckoutCommandHandler : CommandHandler<CartCheckoutCommand, bool>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly AmazonSQSClient _sqsClient;

        public CartCheckoutCommandHandler(IBus bus, ICartRepository cartRepository, IProductRepository productRepository, AmazonSQSClient sqsClient)
            : base(bus)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _sqsClient = sqsClient;
        }

        public override async Task<IExecutionResult<bool>> HandleAsync(CartCheckoutCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                return ValidationErrors(command);
            }

            var cart = await _cartRepository.GetById(command.Id.ToString());

            if (cart == null)
            {
                return ExecutionError(command, ErrorMessages.Cart.DoesNotExistsById);
            }

            var items = cart.Items.Select(x => new CartItem(x.Id)
            {
                Price = x.Price,
                Scale = x.Scale,
                CurrencyCode = x.CurrencyCode,
                Product = _productRepository.GetById(x.Id.ToString()).Result
            }).ToList();

            cart.Items = items;

            var invoice = new Invoice(command.XTeamControl, command.CurrencyCode);
            var invoiceAggregate = new InvoiceAggregate(invoice, cart);

            // SendToSns(invoiceAggregate);

            var result = await _cartRepository.Checkout(command.Id.ToString());

            return new SuccessExecutionResult<bool>(GetType(), result);
        }

        private void SendToSns(InvoiceAggregate invoiceAggregate)
        {
            Log.Information("Sending data to SQS: {data}", invoiceAggregate);

            var tries = 10;
            while (true)
            {
                try
                {
                    var request = new SendMessageRequest
                    {
                        QueueUrl = "https://sqs.us-east-1.amazonaws.com/105029661252/start-checkout", // Leandro
                        // QueueUrl = "https://sqs.us-east-1.amazonaws.com/106868270748/start-checkout", // Carlos
                        MessageBody = JsonUtilities.Serialize(invoiceAggregate)
                    };
                    _sqsClient.SendMessageAsync(request).Wait();
                    break;
                }
                catch
                {
                    if (--tries == 0) throw;
                    Thread.Sleep(1500);
                }
            }
        }
    }
}
