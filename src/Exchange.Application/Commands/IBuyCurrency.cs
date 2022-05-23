using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Exchange.Application.Results;

namespace Exchange.Application.Commands
{
    public interface IBuyCurrency
    {
        Task<BuyResult> Buy(string userId, string currencyName, Decimal amountPesos);
    }
}
