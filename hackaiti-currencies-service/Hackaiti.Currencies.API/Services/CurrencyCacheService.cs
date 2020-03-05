using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hackaiti.Currencies.API.HttpClients;
using Hackaiti.Currencies.API.Model;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Hackaiti.Currencies.API.Services
{
    public class CurrencyCacheService : ICurrencyCacheService
    {
        private const string REDIS_CURRENCIES_KEY = "hackaiti-currencies";
        private readonly ICurrencyHttpClient _currencyHttpClient;
        private readonly IDatabase _database;

        public CurrencyCacheService(ICurrencyHttpClient currencyHttpClient, IDatabase database)
        {
            _currencyHttpClient = currencyHttpClient;
            _database = database;
        }

        public async Task<IEnumerable<Currency>> GetCurrencies()
        {
            var redisValue = _database.StringGet(REDIS_CURRENCIES_KEY);

            if (!redisValue.HasValue)
            {
                var currencies = await _currencyHttpClient.GetCurrencies();

                var ttl = DateTime.Now.Date.AddDays(1).Subtract(DateTime.Now);

                _database.StringSet(REDIS_CURRENCIES_KEY, JsonConvert.SerializeObject(currencies), ttl);

                return currencies;
            }

            return JsonConvert.DeserializeObject<IEnumerable<Currency>>(redisValue.ToString());
        }
    }
}