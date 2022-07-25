using Ledger.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ledger.Domain.BusinessOwners.Events
{
    public class OnLadgerAddedDomainEvent: BaseDomainEvent
    {
        public Ledger? Ledger { get; set; }
    }
}
