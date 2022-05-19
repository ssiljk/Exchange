using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exchange.Api.Model
{
    public sealed class CurrencyDetailModel
    {
        public int Id { get; }
        public string CurrencyName { get; }

        public string QuoteUrl { get; }

        public Decimal MaxLimit { get; }

        public CurrencyDetailModel(int id, string currencyName, string quoteUrl, Decimal maxLimit)
        {
            Id = id;
            CurrencyName = currencyName;
            QuoteUrl = quoteUrl;
            MaxLimit = maxLimit;
        }
    }
}
