using Ledger.api.DTOs;

namespace Ledger.api.Services
{
    public interface ILedgerService
    {
        Task<AddLadgerResponse> LedgerEntiryAsync(AddLadgerRequest model);
    }
}
