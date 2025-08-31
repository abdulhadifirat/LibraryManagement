using Core.Utilities.Results;
using LM.Business.Abstract;
using LM.Entity.Concrete;
using LM.Entity.DTOs.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.UnitOfWorks;
using LM.DataAccess.Abstract;

namespace LM.Business.Concrete;

public class BookManager : IBookServ
{
    private readonly IBookRepo _bookRepo;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public BookManager(IBookRepo bookRepo, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _bookRepo = bookRepo;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<IDataResult<BookResponseDto>> AddAsync(BookCreateRequestDto dto)
    {
        try
        {
            var book = _mapper.Map<Book>(dto);
            await _bookRepo.AddAsync(book);
            await _unitOfWork.CommitAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IDataResult<IEnumerable<BookResponseDto>>> GetAllAsync()
    {
        await
    }

    public async Task<IDataResult<IEnumerable<Book>>> GetAvailableBooksAsync(bool stockStatus)
    {
        await
    }

    public async Task<IDataResult<IEnumerable<Book>>> GetBooksByAuthorAsync(string author)
    {
        await
    }

    public async Task<IDataResult<IEnumerable<Book>>> GetBooksByTitleAsync(string title)
    {
        await
    }

    public async Task<IDataResult<IEnumerable<Book>>> GetBooksPublishedAfterAsync(DateTime publishedDate)
    {
        await
    }

    public async Task<IDataResult<BookResponseDto>> GetByIdAsync(Guid id)
    {
        await
    }

    public async Task<IResult> RemoveAsync(Guid id)
    {
        await
    }

    public async Task<IResult> UpdateAsync(BookUpdateRequestDto dto)
    {
        await
    }
}
