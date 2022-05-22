using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange.Application.Results
{
    public sealed class CurrencyResult
    {
        public string CurrencyName { get; }

        public string QuoteUrl { get;  }

        public Decimal TransactionLimit { get;  }
        public CurrencyResult(string currencyName, string quoteUrl, Decimal transactionLimit )
        {
            CurrencyName = currencyName;
            QuoteUrl = quoteUrl;
            TransactionLimit = transactionLimit;
        }
    }
}
