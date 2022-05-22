using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Exchange.Domain.Transactions;
using Exchange.Application.Results;

namespace Exchange.Application.Repositories
{
    public interface ITransactionRepository
    {
        Task<Decimal> GetTransactionsAmount(string userId, string currencyName);

        Task<TransactionResult> AddTransaction(ITransaction transaction);
    }
}
