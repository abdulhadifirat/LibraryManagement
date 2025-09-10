using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Entity.Concrete
{
    public sealed class Loan : BaseEntity
    {
        public Guid LoanId { get; set; }
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
        public DateTime LoanDate { get; set; } = DateTime.Now;
        public DateTime? ReturnDate { get; set; }
        public bool IsNotReturned { get; set; } = false;
        public DateTime DueDate { get; set; }

        public Book Book { get; set; }
        public User User { get; set; }
    }
}
