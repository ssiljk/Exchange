using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange.Domain.Quotes
{
    public sealed class UndefinedCurrencyException : DomainException
    {
        internal UndefinedCurrencyException(string message)
           : base(message)
        { }
    }
}
