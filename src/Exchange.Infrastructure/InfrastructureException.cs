using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange.Infrastructure
{
    class InfrastructureException : Exception
    {
        internal InfrastructureException(string message)
           : base(message)
        { }
    }
}
