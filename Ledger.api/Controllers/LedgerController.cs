using Ledger.api.DTOs;
using Ledger.api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ledger.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LedgerController : ControllerBase
    {

        private readonly ILogger<LedgerController> _logger;
        private readonly ILedgerService _ledgerService;

        public LedgerController(ILogger<LedgerController> logger, ILedgerService ledgerService)
        {
            _logger = logger;
            _ledgerService = ledgerService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddLadgerRequest ldgerRequest)
        {
          var result = await _ledgerService.LedgerEntiryAsync(ldgerRequest);
            return Ok( result);
        }
    }
}