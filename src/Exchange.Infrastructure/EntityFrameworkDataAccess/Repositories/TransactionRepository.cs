using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Exchange.Domain.Transactions;
using Exchange.Application.Repositories;
using Exchange.Application.Results;
using Exchange.Infrastructure.EntityFrameworkDataAccess.Entities;

namespace Exchange.Infrastructure.EntityFrameworkDataAccess.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly Context _context;

        public TransactionRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    
        public async Task<Decimal> GetTransactionsAmount(string userId, string currencyName)
        {
            return await _context.Transactions
                                        .Where(t => t.UserId == userId
                                               && t.CurrencyName == currencyName
                                               && t.TransactionDate.Month == DateTime.Now.Month)
                                        .Select(t => t.Amount).SumAsync();
        }

        public async Task<TransactionResult> AddTransaction(ITransaction transaction)
        {
            Entities.Transaction entitiesTransaction = new Entities.Transaction();

            entitiesTransaction.UserId = transaction.UserId;
            entitiesTransaction.Amount = transaction.Amount;
            entitiesTransaction.CurrencyName = transaction.CurrencyName;
            entitiesTransaction.TransactionDate = transaction.DateTime;

            var result = await _context.Transactions.AddAsync(entitiesTransaction);

            var resultSave = await _context.SaveChangesAsync();

            TransactionResult transactionResult = new TransactionResult();
            return transactionResult;
        }
    }
}
