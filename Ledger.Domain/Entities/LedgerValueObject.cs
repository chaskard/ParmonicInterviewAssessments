using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ledger.Domain.Entities
{
    public class LedgerValueObject
    {
        public LedgerValueObject(decimal accountBalance, decimal expense = 0, decimal income = 0)
        {
            if (expense > 0)
                accountBalance -= expense;
            else
                accountBalance += income;

            AccountBalance = accountBalance;
        }

        public decimal AccountBalance { get; init; }
    }
}
