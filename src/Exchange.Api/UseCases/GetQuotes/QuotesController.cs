using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Exchange.Application.ExternalApis;

namespace Exchange.Api.UseCases.GetQuotes
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuotesController : ControllerBase
    {
        private readonly IBankApi _bankApi;

        public QuotesController(IBankApi bankApi)
        {
            _bankApi = bankApi;
        }

        [HttpGet("{currencyName}", Name = "GetQuote")]
        public async Task<IActionResult> Get(string currencyName)
        {
            var quote = await _bankApi.Get(currencyName);

            return new ObjectResult(quote);
        }

    }
}
