using Core.Entities;

namespace LM.Entity.DTOs.Book;

public sealed record BookCreateRequestDto(
    string Author,
    string Title,
    DateTime PublishedDate,
    string Description,
    DateTime CreatedAt
    ) : ICreateDto;

