using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Entity.DTOs.Loan;

public sealed record LoanResponseDto (
    Guid Id,
    Guid BookId,
    Guid UserId,
    DateTime LoanDate,
    DateTime? ReturnDate,
    bool IsReturned
    ) : IResponseDto;

