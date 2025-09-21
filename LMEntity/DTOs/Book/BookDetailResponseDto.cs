using Core.Entities;

namespace LM.Entity.DTOs.Book;

public sealed record BookDetailResponseDto(
    Guid Id,
    string Author,
    string Title,
    bool StockStatus,
    string PublishedDate,
    string Description,
    DateTime CreatedAt,
    DateTime UpdatedAt
    ) : IDetailDto;

