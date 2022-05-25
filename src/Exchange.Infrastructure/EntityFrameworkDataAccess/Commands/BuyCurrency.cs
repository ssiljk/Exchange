using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Exchange.Domain.Transactions;
using Exchange.Application.Commands;
using Exchange.Application.Results;
using Exchange.Application.Queries;
using Exchange.Application.ExternalApis;
using Exchange.Application.Repositories;
using Exchange.Infrastructure.EntityFrameworkDataAccess.Entities;

namespace Exchange.Infrastructure.EntityFrameworkDataAccess.Commands
{
    public class BuyCurrency : IBuyCurrency
    {
       
        public readonly IBankApi _bankApi;
        public readonly ITransactionRepository _transactionRepository;

        public BuyCurrency(IBankApi bankApi, ITransactionRepository transactionRepository)
        {
            _bankApi = bankApi;
            _transactionRepository = transactionRepository;
        }
        public async Task<BuyResult> Buy(string userId, string currencyName, Decimal amountPesos)
        {
            decimal transactionAmount;
            var quote = await _bankApi.Get(currencyName);
            var transactionsAmount = await _transactionRepository.GetTransactionsAmount(userId, currencyName);
            if(quote.SaleValue <= 0)
                throw new InfrastructureException($"error in {nameof(quote.SaleValue)} = {quote.SaleValue}");
            if ((transactionsAmount + amountPesos/quote.SaleValue) <= quote.TransactionLimit)       
                transactionAmount = currencyName == "real" ? amountPesos / (quote.SaleValue / 4) : amountPesos / quote.SaleValue;
            else
                return (new BuyResult { UserId = userId, CurrencyAmmount = -1 });

            ITransaction transaction = new Domain.Transactions.Transaction(
                                      userId,
                                      transactionAmount,
                                      currencyName,
                                      DateTime.Now
                                     ) ;

            var insertedTransactionId = await _transactionRepository.InsertTransaction(transaction);
            return (new BuyResult {Id = insertedTransactionId,
                                   UserId = userId,
                                   CurrencyAmmount = transactionAmount,
                                   CurrencyName = currencyName,
                                   DateTime = transaction.DateTime });
        }
    }
}
