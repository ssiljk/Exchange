using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Exchange.Domain.Transactions;

namespace Exchange.Application.Repositories
{
    public interface ITransactionRepository
    {
        Task<Decimal> GetTransactionsAmount(string userId, string currencyName);
    }
}
