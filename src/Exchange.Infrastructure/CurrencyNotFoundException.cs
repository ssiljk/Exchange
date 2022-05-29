using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange.Infrastructure
{
    public class CurrencyNotFoundException : Exception
    {
        internal CurrencyNotFoundException(string message)
           : base(message)
        { }
    }
}
