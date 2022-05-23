using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange.Application.Results
{
    public class QuoteResult
    {
        public string CurrencyName { get; set; }
        public Decimal BuyValue { get; set; }

        public Decimal SaleValue { get; set; }

        public DateTime DateTime { get; set; }
    }
}
