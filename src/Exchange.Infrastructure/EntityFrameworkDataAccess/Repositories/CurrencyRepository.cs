using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Exchange.Domain.Quotes;
using Exchange.Application.Repositories;

namespace Exchange.Infrastructure.EntityFrameworkDataAccess.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly Context _context;

        public CurrencyRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Currency> Get(string currencyName)
        {
            Entities.Currency entityCurrency = await _context
                                                     .Currencies
                                                     .FirstOrDefaultAsync(c => c.Name == currencyName);

            Currency currency = new Currency();
            currency.Name = entityCurrency.Name;
            currency.Url = entityCurrency.Url;
            currency.MaxLimit = entityCurrency.MaxLimit;

            return currency;
        }

    }
}
