using System.Threading.Tasks;
using Hackaiti.CheckoutService.Worker.Model.InvoiceApi;
using Refit;

namespace Hackaiti.CheckoutService.Worker.Services
{
    public interface IHackatonZupApiService
    {
        [Post("/invoices")]
        Task PostInvoice([Body]Invoice invoice, [Header("x-team-control")]string xTeamControl);
    }
}