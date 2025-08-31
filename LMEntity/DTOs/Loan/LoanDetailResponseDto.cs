using Core.Entities;

namespace LM.Entity.DTOs.Loan;

public sealed record LoanDetailResponseDto(
    Guid Id,
    DateTime LoanDate,
    DateTime? ReturnDate,
    bool IsReturned
    ) : IDetailDto;

