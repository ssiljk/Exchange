using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Exchange.Domain.Quotes;

namespace Exchange.Application.Repositories
{
    public interface IQuoteApi
    {
        Task<Quote> Get(string currencyName);
    }
}
