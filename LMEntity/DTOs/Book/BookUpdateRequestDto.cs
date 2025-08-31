using Core.Entities;

namespace LM.Entity.DTOs.Book;

public sealed record BookUpdateRequestDto(
    Guid Id,
    string Author,
    string Title,
    bool StockStatus,
    DateTime UpdatedAt
    ) : IUpdateDto;

