using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Exchange.Application.Results;

namespace Exchange.Application.Queries
{
    public interface IQuotesQueries
    {
        Task<QuoteResult> GetQuote(string currency);
    }
}
