using Ledger.Domain.Base;
using Ledger.Domain.BusinessOwners.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ledger.Domain.BusinessOwners
{
    public partial class Ledger: IAggregateRoot
    {
        public Ledger AddLedger(DateTime date,
            string description,
            string notes,
            decimal income,
            decimal expense)
        {
           
            this.Update(date, description, notes, income, expense); 
            var addEvent = new OnLadgerAddedDomainEvent()
            {
                Ledger = this
            };
            AddEvent(addEvent);
            return this;
        }
        public void Update(DateTime date,
            string description,
            string notes,
            decimal income,
            decimal expense)
        {
            Date = date;
            Description = description;
            Notes = notes;
            Income = income;
            Expense = expense;
        }
    }
}
