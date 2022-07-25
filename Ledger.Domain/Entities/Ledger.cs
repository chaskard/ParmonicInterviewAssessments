using Ledger.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ledger.Domain.BusinessOwners
{
    public partial class Ledger : BaseEntity<int>
    {

        public DateTime Date { get; private set; }
        public string? Description { get; private set; }
        public string? Notes { get; private set; }
        public decimal Income { get; private set; }
        public decimal Expense { get; private set; }
        public decimal AccountBalance { get; private set; }

    }
}
