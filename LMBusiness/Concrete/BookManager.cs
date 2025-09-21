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
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

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
            book.CreatedAt = DateTime.UtcNow; 

            await _bookRepo.AddAsync(book);
            await _unitOfWork.CommitAsync();

            var bookResponse = _mapper.Map<BookResponseDto>(book);
            return new SuccesDataResult<BookResponseDto>(bookResponse, "Book added successfully.");
        }
        catch (Exception e)
        {
            return new ErrorDataResult<BookResponseDto>(e.Message);
        }
    }

    public async Task<IDataResult<IEnumerable<BookResponseDto>>> GetAllAsync()
    {
        try
        {
            var books = await _bookRepo.GetAll().ToListAsync();
            if (books == null)
            {
                return new ErrorDataResult<IEnumerable<BookResponseDto>>("No books found.");
            }
            var bookResponses = _mapper.Map<IEnumerable<BookResponseDto>>(books);
            return new SuccesDataResult<IEnumerable<BookResponseDto>>(bookResponses);
        }
        catch (Exception)
        {

            return new ErrorDataResult<IEnumerable<BookResponseDto>>("An error occurred while retrieving books.");
        }
    }

    public async Task<IDataResult<IEnumerable<Book>>> GetAvailableBooksAsync(bool stockStatus)
    {
        try
        {
            // Fix: Use '==' for comparison, not '=' for assignment
            var books = await _bookRepo.GetAll(b => b.IsActive == true).ToListAsync();
            if (books == null)
            {
                return (IDataResult<IEnumerable<Book>>)new ErrorDataResult<IEnumerable<Book>>("No available books found.");
            }
            var bookResponses = _mapper.Map<IEnumerable<Book>>(books);

            return (IDataResult<IEnumerable<Book>>)new SuccesDataResult<IEnumerable<Book>>(books);
        }
        catch (Exception)
        {
            return (IDataResult<IEnumerable<Book>>)new ErrorDataResult<IEnumerable<Book>>("An error occurred while retrieving available books.");
        }
    }

  

    public async Task<IDataResult<BookResponseDto>> GetByIdAsync(Guid id)
    {
        try
        {
            var book = await _bookRepo.GetAsync(b => b.Id == id);
            if (book == null)
            {
                return (IDataResult<BookResponseDto>)  new ErrorDataResult<BookResponseDto>("Book not found.");
            }
            var bookResponse = _mapper.Map<BookResponseDto>(book);
            return (IDataResult<BookResponseDto>) new SuccesDataResult<BookResponseDto>(bookResponse);

        }
        catch (Exception)
        {

           return (IDataResult<BookResponseDto>) new ErrorDataResult<BookResponseDto>("An error occurred while retrieving the book.");
        }
    }

    public async Task<IResult> RemoveAsync(Guid id)
    {
        try
        {
            var book = await _bookRepo.GetAsync(b => b.Id == id);
            if (book == null)
            {
                return new ErrorResult("Book not found.");
            }
            book.UpdatedAt = DateTime.Now;
            book.IsActive=false;
            book.IsDeleted=true;
            _bookRepo.Update(book);
            await _unitOfWork.CommitAsync();
            return new SuccesResult("Book removed successfully.");
        }
        catch (Exception)
        {

            return new ErrorResult("An error occurred while removing the book.");
        }
    }

    public async Task<IResult> UpdateAsync(BookUpdateRequestDto dto)
    {
        try
        {
            var book = _mapper.Map<Book>(dto);
            book.UpdatedAt = DateTime.Now;
            _bookRepo.Update(book);
            await _unitOfWork.CommitAsync();
            return new SuccesResult("Book updated successfully.");
        }
        catch (Exception)
        {

            return new ErrorResult("An error occurred while updating the book.");
        }

        
    }

    public async Task<IDataResult<IEnumerable<Book>>> GetBooksById(Guid id)
    {
        try
        {
            var books = await _bookRepo.GetAll(b => b.Id == id).ToListAsync();
            if (books == null || !books.Any())
            {
                return (IDataResult<IEnumerable<Book>>)new ErrorDataResult<IEnumerable<Book>>("No books found with the specified ID.");
            }
            return (IDataResult<IEnumerable<Book>>)new SuccesDataResult<IEnumerable<Book>>(books);
        }
        catch (Exception)
        {
            return (IDataResult<IEnumerable<Book>>)new ErrorDataResult<IEnumerable<Book>>("An error occurred while retrieving books by ID.");
        }
    }

    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}
