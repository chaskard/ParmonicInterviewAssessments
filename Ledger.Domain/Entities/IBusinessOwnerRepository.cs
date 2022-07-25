using Ledger.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ledger.Domain.Entities
{
    public interface IBusinessOwnerRepository : IAsyncRepository<BusinessOwner>
    {
    }
}
