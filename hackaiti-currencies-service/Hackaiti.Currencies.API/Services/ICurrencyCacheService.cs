using System.Collections.Generic;
using System.Threading.Tasks;
using Hackaiti.Currencies.API.Model;

namespace Hackaiti.Currencies.API.Services
{
    public interface ICurrencyCacheService
    {
        Task<IEnumerable<Currency>> GetCurrencies();
    }
}