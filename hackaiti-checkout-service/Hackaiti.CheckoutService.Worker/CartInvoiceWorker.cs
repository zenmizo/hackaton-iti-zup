using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Amazon.SQS;
using Amazon.SQS.Model;
using Hackaiti.CheckoutService.Worker.Model;
using Hackaiti.CheckoutService.Worker.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Hackaiti.CheckoutService.Worker
{
    public class CartInvoiceWorker : BackgroundService
    {
        private const string QUEUE_URL = "https://sqs.us-east-1.amazonaws.com/105029661252/hackaiti-testing";
        private readonly ILogger<CartInvoiceWorker> _logger;
        private readonly ICurrenciesApiService _currenciesService;
        private readonly ICartService _cartService;
        
        public CartInvoiceWorker(ILogger<CartInvoiceWorker> logger, ICartService cartService, ICurrenciesApiService currenciesService)
        {
            _cartService = cartService;
            _currenciesService = currenciesService;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"Initializing {nameof(CartInvoiceWorker)}.");

            var client = new AmazonSQSClient();

            var receiveMessageRequest = new ReceiveMessageRequest()
            {
                QueueUrl = QUEUE_URL,
                MaxNumberOfMessages = 5,
                VisibilityTimeout = 120,
                WaitTimeSeconds = 10
            };

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Getting messages from {queueURL}", QUEUE_URL);

                var receiveMessageResponse = await client.ReceiveMessageAsync(receiveMessageRequest);

                foreach (var message in receiveMessageResponse.Messages)
                {
                    _logger.LogInformation("Processing {message}", message.Body);

                    var cart = JsonConvert.DeserializeObject<Cart>(message.Body);
                    var total = await GetTotal(cart);
                    cart.Total = total;

                    _logger.LogInformation("Invoice payload: {payload}", cart);

                    await client.DeleteMessageAsync(new DeleteMessageRequest()
                    {
                        QueueUrl = QUEUE_URL,
                        ReceiptHandle = message.ReceiptHandle
                    });
                }
            }
        }

        private async Task<CartTotal> GetTotal(Cart cart)
        {
            var currencies = await _currenciesService.GetCurrencies();

            var usd2brl = currencies.Single(t => string.Equals(t.CurrencyCode, "USD_TO_BRL", StringComparison.CurrentCultureIgnoreCase));
            var usd2eur = currencies.Single(t => string.Equals(t.CurrencyCode, "USD_TO_EUR", StringComparison.CurrentCultureIgnoreCase));

            var usd2brl_factor = GetFactor(usd2brl.CurrencyValue, usd2brl.Scale);
            var usd2eur_factor = GetFactor(usd2eur.CurrencyValue, usd2eur.Scale);
            var brl2usd_factor = 1 / usd2brl_factor;
            var eur2usd_factor = 1 / usd2eur_factor;

            var currencyConversionTable = new Dictionary<string, double>()
            {
                { "USD-BRL", usd2brl_factor },
                { "USD-EUR", usd2eur_factor },
                { "USD-USD", 1 },

                { "EUR-BRL", eur2usd_factor * usd2brl_factor },
                { "EUR-EUR", 1 },
                { "EUR-USD", eur2usd_factor },

                { "BRL-BRL", 1 },
                { "BRL-EUR", brl2usd_factor * usd2eur_factor },
                { "BRL-USD", brl2usd_factor }
            };

            var total = new CartTotal()
            {
                Amount = 0,
                Scale = 2,
                CurrencyCode = cart.DesiredCurrencyCode
            };

            foreach (var item in cart.Items)
            {
                var itemPrice = item.Price / Math.Pow(10, item.Scale);
                var conversionKey = $"{item.CurrencyCode}-{cart.DesiredCurrencyCode}".ToUpper();
                var conversionFactor = currencyConversionTable[conversionKey];
                var itemAmount = Convert.ToInt64(itemPrice * conversionFactor * 100);

                total.Amount += itemAmount;
            }

            return total;
        }

        private double GetFactor(long currencyValue, long scale)
        {
            return currencyValue / Math.Pow(10, scale);
        }
    }
}
