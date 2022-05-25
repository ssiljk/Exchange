using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Exchange.Application.Queries;
using Exchange.Application.Results;
using Serilog;

namespace Exchange.Infrastructure.EntityFrameworkDataAccess.Queries
{
    public class CurrencyQuery : ICurrencyQuery
    {
        private readonly Context _context;

        public CurrencyQuery(Context context)
        {
            _context = context;
        }

        public async Task<CurrencyResult> GetCurrency(string currencyName)
        {
            Log.Information($"Currency {currencyName} is being queried");
            Entities.Currency currency = await _context
                                              .Currencies
                                              .FirstOrDefaultAsync(c => c.Name == currencyName);
            if (currency == null)
            {
                Log.Error($"Currency {currencyName} is not being traded");
                throw new CurrencyNotFoundException($"Currency {currencyName} is not being traded");
            }
               
            CurrencyResult currencyResult = new CurrencyResult
                                            (currency.Name, currency.Url, currency.MaxLimit);
            return currencyResult;
        }

    }
}
