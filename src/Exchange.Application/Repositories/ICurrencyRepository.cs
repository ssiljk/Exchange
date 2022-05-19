using System;
using System.Collections.Generic;
using System.Text;
using Exchange.Domain.Quotes;
using System.Threading.Tasks;

namespace Exchange.Application.Repositories
{
    public interface ICurrencyRepository
    {
        Task<Currency> Get(string currencyName);
    }
}
