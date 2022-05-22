using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Exchange.Application.Commands;

namespace Exchange.Api.UseCases.BuyCurrencies
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuyController : ControllerBase
    {
        private readonly IBuyCurrency _buyCurrency;

        public BuyController(IBuyCurrency buyCurrency)
        {
            _buyCurrency = buyCurrency;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromQuery] string userId,
                                              [FromQuery] string currencyName,
                                              [FromQuery] Decimal amountPesos)
        {
            var buyResult = await _buyCurrency.Buy(userId, currencyName, amountPesos);
            return Created("creado", buyResult);
        }
    }
}
