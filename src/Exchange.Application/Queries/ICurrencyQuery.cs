using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Exchange.Application.Results;

namespace Exchange.Application.Queries
{
    public interface ICurrencyQuery
    {
        Task<CurrencyResult> GetCurrency(string currency);
    }
}
