using Amazon.SQS;
using Amazon.SQS.Model;
using Backend.Domain.Core.Bus;
using Backend.Domain.Core.Commands;
using Backend.Domain.Core.Results;
using Backend.Domain.Models.CartModel;
using Backend.Domain.Models.CartModel.Commands;
using Backend.Domain.Models.CartModel.Repositories;
using Backend.Domain.Models.InvoiceModel;
using Backend.Domain.Models.ProductModel;
using Backend.Domain.Models.ProductModel.Repositories;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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

            var cart = _cartRepository.GetById(command.id.ToString()).Result;
            var items = cart.items.Select(x => new CartItem()
            {
                id = x.id,
                price = x.price.Value,
                scale = x.scale.Value,
                currencyCode = x.currencyCode,
                product = _productRepository.GetById(x.id.ToString()).Result
            }).ToList();

            cart.items = items;

            var invoice = new Invoice()
            {
                invoice = new InvoiceMetadata()
                {
                    xTeamControl = command.xTeamControl,
                    currencyCode = command.currencyCode
                },
                cart = cart
            };

            Log.Information("Sending data to SQS: {@data}", invoice);

            var jsonPayload = JsonConvert.SerializeObject(invoice, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize
            });

            SendToSns(jsonPayload);

            _cartRepository.Checkout(command.id.ToString()).Wait();

            return new SuccessOperationResult<Cart>("checkout complete");
        }

        public void SendToSns(string jsonPayload)
        {
            var tries = 10;
            while (true)
            {
                try
                {
                    var request = new SendMessageRequest()
                    {
                        QueueUrl = "https://sqs.us-east-1.amazonaws.com/105029661252/start-checkout", // Leandro
                        //QueueUrl = "https://sqs.us-east-1.amazonaws.com/106868270748/start-checkout", // Carlos
                        MessageBody = jsonPayload
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
