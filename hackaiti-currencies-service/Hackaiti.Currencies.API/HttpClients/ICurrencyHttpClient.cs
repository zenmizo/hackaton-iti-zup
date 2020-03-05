using System.Collections.Generic;
using System.Threading.Tasks;
using Hackaiti.Currencies.API.Model;

namespace Hackaiti.Currencies.API.HttpClients
{
    public interface ICurrencyHttpClient
    {
        Task<IEnumerable<Currency>> GetCurrencies();
    }
}