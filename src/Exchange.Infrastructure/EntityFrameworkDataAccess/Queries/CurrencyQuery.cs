using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Exchange.Application.Queries;
using Exchange.Application.Results;

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
            Entities.Currency currency = await _context
                                              .Currencies
                                              .FirstOrDefaultAsync(c => c.Name == currencyName);

            CurrencyResult currencyResult = new CurrencyResult
                                            (currency.Name, currency.Url);
            return currencyResult;
        }

    }
}
