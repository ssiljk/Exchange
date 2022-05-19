using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Exchange.Application.Queries;
using Exchange.Api.Model;

namespace Exchange.Api.UseCases.GetCurrencies
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrenciesController : ControllerBase
    {
        private readonly ICurrencyQuery _currencyQuery;

        public CurrenciesController(ICurrencyQuery currencyQuery)
        {
            _currencyQuery = currencyQuery;
        }

        /// <summary>
        /// Get currency information
        /// </summary>


        [HttpGet("{currencyName}", Name = "GetCurrency")]
        public async Task<IActionResult> Get(string currencyName)
        {
            var currency = await _currencyQuery.GetCurrency(currencyName);

            var currencyDetailModel = new CurrencyDetailModel(0, currency.CurrencyName, currency.QuoteUrl, 100);

            return new ObjectResult(currencyDetailModel);
        }
    }
}
