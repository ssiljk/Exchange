using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange.Application.Results
{
    public class TransactionResult
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public Decimal Amount { get; set; }

        public string CurrencyName { get; set; }

        public DateTime TransactionDate { get; set; }
    }
}
