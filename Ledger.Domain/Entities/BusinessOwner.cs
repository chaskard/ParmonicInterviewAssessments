using Ledger.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ledger.Domain.Entities
{

    public partial class BusinessOwner : BaseEntity<int>
    {
        public BusinessOwner()
        {
            Ledgers = new HashSet<Ledger>();
        }

        public string CompanyName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Address { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public int DepartmentId { get; private set; }
        public float CoefficientsSalary { get; private set; }

        public virtual ICollection<Ledger> Ledgers { get; private set; }
    }
}
