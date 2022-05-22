using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange.Infrastructure.EntityFrameworkDataAccess.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public string  UserId { get; set; }

        public Decimal Amount { get; set; }

        public string CurrencyName { get; set; }

        public DateTime TransactionDate { get; set; }

    }
}
