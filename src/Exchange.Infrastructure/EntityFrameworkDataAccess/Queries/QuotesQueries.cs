using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Exchange.Application.Queries;
using Exchange.Application.Results;

namespace Exchange.Infrastructure.EntityFrameworkDataAccess.Queries
{
    class QuotesQueries : IQuotesQueries
    {
        private readonly Context _context;

        public QuotesQueries(Context context)
        {
            _context = context;
        }
        public async Task<QuoteResult> GetQuote(string currencyName)
        {
            Entities.Currency currency = await _context
                                              .Currencies
                                              .FirstOrDefaultAsync(c => c.Name == currencyName);
            QuoteResult quoteResult = new QuoteResult();
            return quoteResult;
        }
    }
}
