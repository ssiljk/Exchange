using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange.Application.Results
{
    public class BuyResult
    {
        public string UserId { get; set; }

        public string CurrencyName { get; set; }
        public Decimal CurrencyAmmount { get; set; }

        public DateTime DateTime { get; set; }

     
    }
}
