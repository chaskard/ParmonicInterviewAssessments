using Ledger.Domain.Base;
using Ledger.Domain.Interfaces;
using Ledger.Infrastucture.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ledger.Infrastucture
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EFContext _dbContext;

        public UnitOfWork(EFContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IAsyncRepository<T> AsyncRepository<T>() where T : BaseEntity => new RepositoryBase<T>(_dbContext);

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
