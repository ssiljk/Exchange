using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange.Domain.Transactions
{
    public interface ITransaction
    {
        public string UserId { get; }

        public Decimal Amount { get; }

        public string CurrencyName { get; set; }

        public DateTime DateTime { get; }
    }
}
