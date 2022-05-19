using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange.Domain.Quotes
{
    public class Currency
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public Decimal MaxLimit { get; set; }

    }
}
