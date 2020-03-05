using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hackaiti.CheckoutService.Worker.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;

namespace Hackaiti.CheckoutService.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<CartInvoiceWorker>();

                    services.AddTransient<ICartService, CartService>();

                    services.AddSingleton<ICurrenciesApiService>(serviceProvider =>
                    {
                        return RestService.For<ICurrenciesApiService>("http://localhost:8000");
                    });
                });
    }
}
