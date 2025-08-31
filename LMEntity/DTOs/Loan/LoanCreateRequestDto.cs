using Core.Entities;

namespace LM.Entity.DTOs.Loan;

public sealed record LoanCreateRequestDto(
    Guid BookId,
    Guid UserId,
    DateTime LoanDate
    ) : ICreateDto;

