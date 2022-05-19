using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange.Application.Results
{
    public sealed class CurrencyResult
    {
        public string CurrencyName { get; }

        public string QuoteUrl { get;  }


        public CurrencyResult(string currencyName, string quoteUrl)
        {
            CurrencyName = currencyName;
            QuoteUrl = quoteUrl;
        }
    }
}
