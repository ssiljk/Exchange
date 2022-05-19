using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange.Domain.Quotes
{
    public class Quote
    {
        public Decimal  BuyValue { get; set; }

        public Decimal SaleValue { get; set; }

        public DateTime DateTime { get; set; }
    }
}
