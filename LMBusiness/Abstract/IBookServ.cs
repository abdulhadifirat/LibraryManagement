using Core.Business;
using Core.Utilities.Results;
using LM.Entity.Concrete;
using LM.Entity.DTOs.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Business.Abstract;

public interface IBookServ : IGenericServ<Book, BookResponseDto, BookCreateRequestDto, BookUpdateRequestDto, BookDetailResponseDto>
{
   
    Task<IDataResult<IEnumerable<Book>>> GetAvailableBooksAsync(bool stockStatus);

    Task<IDataResult<IEnumerable<BookResponseDto>>> GetAllAsync();

    Task<IDataResult<IEnumerable<Book>>> GetBooksById(Guid id);
    Task<IDataResult<BookResponseDto>> AddAsync(BookCreateRequestDto dto);
   
}
