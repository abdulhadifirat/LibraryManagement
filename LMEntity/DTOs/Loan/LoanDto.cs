using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Entity.DTOs.Loan
{
    public sealed record LoanDto(
    Guid Id,
    DateTime LoanDate,
    DateTime ReturnDate
);

}
