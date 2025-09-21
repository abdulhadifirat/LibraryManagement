using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Entity.DTOs.Book;

public sealed record BookResponseDto(
    Guid Id,
    string Author,
    string Title,
    bool StockStatus,
    string PublishedDate,
    string Description
    ) : IResponseDto;