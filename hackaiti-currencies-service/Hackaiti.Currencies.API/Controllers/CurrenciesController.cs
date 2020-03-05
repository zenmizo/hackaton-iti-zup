using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hackaiti.Currencies.API.Model;
using Hackaiti.Currencies.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace Hackaiti.Currencies.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrenciesController : ControllerBase
    {
        private readonly ILogger<CurrenciesController> _logger;
        private readonly ICurrencyCacheService _currencyCacheService;

        public CurrenciesController(ILogger<CurrenciesController> logger, ICurrencyCacheService currencyCacheService)
        {
            _logger = logger;
            _currencyCacheService = currencyCacheService;
        }

        [HttpGet]
        public async Task<IEnumerable<Currency>> Get()
        {
            var currencies = await _currencyCacheService.GetCurrencies();

            return currencies;
        }
    }
}
