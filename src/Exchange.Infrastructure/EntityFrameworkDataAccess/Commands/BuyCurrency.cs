using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Exchange.Application.Commands;
using Exchange.Application.Results;
using Exchange.Application.Queries;
using Exchange.Application.ExternalApis;
using Exchange.Application.Repositories;


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
            var quote = await _bankApi.Get(currencyName);
            var transactionsAmount = await _transactionRepository.GetTransactionsAmount(userId, currencyName);
            if((transactionsAmount + amountPesos/quote.SaleValue) <= quote.TransactionLimit))



        }
    }
}
