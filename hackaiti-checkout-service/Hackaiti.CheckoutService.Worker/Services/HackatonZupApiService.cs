using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Hackaiti.CheckoutService.Worker.Model.InvoiceApi;
using Newtonsoft.Json;
using Refit;

namespace Hackaiti.CheckoutService.Worker.Services
{
    public class HackatonZupApiService : IHackatonZupApiService
    {
        public async Task PostInvoice([Body] Invoice invoice, [Header("x-team-control")] string xTeamControl)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9000");
                
                client.Timeout = TimeSpan.FromSeconds(10);

                client.DefaultRequestHeaders.Add("x-team-control", xTeamControl);

                await client.PostAsync("/invoices", new StringContent(JsonConvert.SerializeObject(invoice), Encoding.UTF8, "application/json"));
            }
        }
    }
}