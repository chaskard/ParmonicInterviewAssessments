using Ledger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ledger.Infrastucture.Repositories
{
    public class BusinessOwnerRepository : RepositoryBase<BusinessOwner>
        , IBusinessOwnerRepository
    {
        public BusinessOwnerRepository(EFContext dbContext) : base(dbContext)
        {
        }
    }
}
