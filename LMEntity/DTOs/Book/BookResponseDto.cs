using Core.Entities;
using LM.Entity.Concrete;
using LM.Entity.DTOs.Loan;

namespace LM.Entity.DTOs.Book;

public sealed record BookResponseDto(
    Guid Id,
    string Author,
    string Title,
    bool StockStatus,
    string PublishedDate,
    string Description,
    DateTime CreatedAt,
    ICollection<LoanDto> Loans
) : IResponseDto;
