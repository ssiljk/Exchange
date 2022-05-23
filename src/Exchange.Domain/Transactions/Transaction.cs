using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange.Domain.Transactions
{
    public class Transaction : ITransaction
    {
        public string UserId { get; }

        public Decimal Amount { get; }

        public string CurrencyName { get; }

        public DateTime DateTime { get; }

        public Transaction(string userId, Decimal amount, string currencyName, DateTime dateTime)
        {
            UserId = userId;
            Amount = amount;
            CurrencyName = currencyName;
            DateTime = dateTime;
        }
    }
}
