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

                    services.AddSingleton<ICurrenciesApiService>(serviceProvider =>
                    {
                        return RestService.For<ICurrenciesApiService>("http://localhost:8000");
                    });

                    services.AddTransient<IHackatonZupApiService, HackatonZupApiService>();

                    // services.AddSingleton<IHackatonZupApiService>(serviceProvider =>
                    // {
                    //     return RestService.For<IHackatonZupApiService>(new System.Net.Http.HttpClient()
                    //     {
                    //         BaseAddress = new Uri("http://localhost:9000"),
                    //         Timeout = TimeSpan.FromSeconds(5)
                    //     });
                    // });
                });
    }
}
