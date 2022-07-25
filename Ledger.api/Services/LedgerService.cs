using Ledger.api.DTOs;
using Ledger.Domain.Interfaces;

namespace Ledger.api.Services
{
    public class LedgerService : BaseService, ILedgerService
    {
        public LedgerService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public async Task<AddLadgerResponse> LedgerEntiryAsync(AddLadgerRequest model)
        {
            var repository = UnitOfWork.AsyncRepository<Domain.BusinessOwners.Ledger>();
            var ledger = await repository.GetAsync(_ => _.Date == model.Date && _.Description == model.Description);
            if(ledger == null)
            {
                ledger = new Domain.BusinessOwners.Ledger();
                ledger.AddLedger(model.Date, model.Description, model.Notes, model.Expense, model.Income);
                await repository.AddAsync(ledger);
                await UnitOfWork.SaveChangesAsync();
                return new AddLadgerResponse()
                {
                    ResponseMEssage = "Sucessfully add entry to ledger."
                };
            }
            throw new Exception("Duplicate entry found.");
        }
    }
}
