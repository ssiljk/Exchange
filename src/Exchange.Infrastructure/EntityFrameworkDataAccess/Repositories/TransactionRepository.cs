using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Exchange.Domain.Transactions;
using Exchange.Application.Repositories;

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
    }
}
