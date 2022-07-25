using System.ComponentModel.DataAnnotations;

namespace Ledger.api.DTOs
{
    public class AddLadgerRequest
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Description { get; set; }
        public string Notes { get; set; }
        public decimal Income { get; set; }
        public decimal Expense { get; set; }
    }
}
