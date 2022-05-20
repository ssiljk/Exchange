using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Exchange.Domain.Quotes;

namespace Exchange.Application.ExternalApis
{
    public interface IBankApi
    {
        Task<Quote> Get(string currencyName);
    }
}
