using Amazon.SQS;
using Amazon.SQS.Model;
using Backend.Domain.Core.Bus;
using Backend.Domain.Core.Commands;
using Backend.Domain.Core.Results;
using Backend.Domain.Models.CartModel;
using Backend.Domain.Models.CartModel.Commands;
using Backend.Domain.Models.CartModel.Repositories;
using Backend.Domain.Models.InvoiceModel;
using Backend.Domain.Models.ProductModel.Repositories;
using Newtonsoft.Json;
using Serilog;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Infra.Repositories
{
    public sealed class CartCheckoutCommandHandler : CommandHandler<CartCheckoutCommand, Cart>
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

        public override AbstractOperationResult<Cart> Handle(CartCheckoutCommand command)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return new FailureOperationResult<Cart>("checkout error");
            }

            if (!_cartRepository.ExistsById(command.id.ToString()))
            {
                return new FailureOperationResult<Cart>("cart with specified id does not exists");
            }

            var invoice = new Invoice()
            {
                invoice = new InvoiceMetadata()
                {
                    xTeamControl = command.xTeamControl,
                    currencyCode = command.currencyCode,

                },
                cart = new Cart()
                {
                    customerId = command.customerId,
                    id = command.id,
                    status = command.status,
                    items = command.items.Select(item => new CartItem()
                    {
                        curencyCode = item.curencyCode,
                        price = item.price,
                        id = item.id,
                        scale = item.scale,
                        product = item.product
                    }).ToList()
                }
            };

            var jsonPayload = JsonConvert.SerializeObject(invoice);

            Log.Information("Sending data to SQS: {payload}", jsonPayload);

            // TODO: send to SQS
            var request = new SendMessageRequest()
            {
                QueueUrl = "https://sqs.us-east-1.amazonaws.com/105029661252/start-checkout",
                MessageBody = jsonPayload
            };

            _sqsClient.SendMessageAsync(request).Wait();

            _cartRepository.Checkout(command.id.ToString()).Wait();

            return new SuccessOperationResult<Cart>("checkout complete");
        }
    }
}
