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
                client.BaseAddress = new Uri(WorkerConfig.HackatonZupBaseAddress);
                
                client.Timeout = TimeSpan.FromSeconds(10);

                client.DefaultRequestHeaders.Add("x-team-control", xTeamControl);

                var response = await client.PostAsync("/invoices", new StringContent(JsonConvert.SerializeObject(invoice), Encoding.UTF8, "application/json"));

                response.EnsureSuccessStatusCode();
            }
        }
    }
}