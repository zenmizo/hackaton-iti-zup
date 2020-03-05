using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Hackaiti.Currencies.API.Model;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Hackaiti.Currencies.API.HttpClients
{
    public class CurrencyHttpClient : ICurrencyHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<ApiConfig> apiConfig;

        public CurrencyHttpClient(HttpClient httpClient, IOptions<ApiConfig> _apiConfig)
        {
            _httpClient = httpClient;
            apiConfig = _apiConfig;
        }

        public async Task<IEnumerable<Currency>> GetCurrencies()
        {
            var uri = apiConfig.Value.CurrenciesApiURI;

            var jsonResponse = await _httpClient.GetStringAsync(uri);

            var currencies = JsonConvert.DeserializeObject<IEnumerable<Currency>>(jsonResponse);

            return currencies;
        }


    }
}