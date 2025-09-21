using Core.Entities;

namespace LM.Entity.DTOs.Book;

public sealed record BookCreateRequestDto(
    string Author,
    string Title,
    string PublishedDate,
    string Description

    ) : ICreateDto;

