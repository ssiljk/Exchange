using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange.Domain.Quotes
{
    public class Quote
    {
        public string CurrencyName { get; set; }
        public Decimal  BuyValue { get; set; }

        public Decimal SaleValue { get; set; }

        public Decimal TransactionLimit { get; set; }

        public DateTime DateTime { get; set; }
    }
}
