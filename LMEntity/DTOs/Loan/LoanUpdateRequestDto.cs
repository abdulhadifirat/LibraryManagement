using Core.Entities;

namespace LM.Entity.DTOs.Loan;

public sealed record LoanUpdateRequestDto(
    Guid Id,
    DateTime? ReturnDate,
    bool IsReturned
    ) : IUpdateDto;

