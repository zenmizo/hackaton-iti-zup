using System.Collections.Generic;
using System.Threading.Tasks;
using Hackaiti.CheckoutService.Worker.Model;
using Refit;

namespace Hackaiti.CheckoutService.Worker.Services
{
    public interface ICurrenciesApiService
    {
        [Get("/currencies")]
        Task<IEnumerable<Currency>> GetCurrencies();
         
    }
}