using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange.Domain.Transactions
{
    public interface ITransaction
    {
        public string UserId { get; }

        public Decimal CurrencyAmmount { get; }

        public DateTime DateTime { get; }
    }
}
