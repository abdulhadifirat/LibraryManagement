using AutoMapper;
using Core.UnitOfWorks;
using Core.Utilities.Results;
using LM.Business.Abstract;
using LM.DataAccess.Abstract;
using LM.Entity.Concrete;
using LM.Entity.DTOs.Loan;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Business.Concrete;

public class LoanManager : ILoanServ
{
    private readonly ILoanRepo _loanRepo;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public LoanManager(ILoanRepo loanRepo, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _loanRepo = loanRepo;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<IDataResult<LoanResponseDto>> AddAsync(LoanCreateRequestDto dto)
    {
        try
        {
            var loan = _mapper.Map<Loan>(dto);
            await _loanRepo.AddAsync(loan);
            await _unitOfWork.CommitAsync();
            var loanResponse = _mapper.Map<LoanResponseDto>(loan);
            return (IDataResult<LoanResponseDto>)(new SuccesDataResult<LoanResponseDto>(loanResponse, "Loan added successfully."));
        }
        catch (Exception)
        {

            return (IDataResult<LoanResponseDto>)new ErrorDataResult<LoanResponseDto>("An error occurred while adding the loan.");
        }
    }

    public async Task<IDataResult<IEnumerable<Loan>>> GetActiveLoansAsync(bool isNotReturned)
    {
        try
        {
            var loan = await _loanRepo.GetAll(l => l.IsNotReturned == isNotReturned).OrderByDescending(l => l.LoanDate).ToListAsync();
            if (loan == null)
            {
                return (IDataResult<IEnumerable<Loan>>)new ErrorDataResult<IEnumerable<Loan>>("All loans returned.");
            }

            return (IDataResult<IEnumerable<Loan>>)new SuccesDataResult<IEnumerable<Loan>>(loan);
        }
        catch (Exception)
        {
            return (IDataResult<IEnumerable<Loan>>)new ErrorDataResult<IEnumerable<Loan>>("An error occurred while retrieving active loans.");
        }
    }

    public async Task<IDataResult<IEnumerable<LoanResponseDto>>> GetAllAsync()
    {
        try
        {
            var loan = await _loanRepo.GetAll(l=>!l.IsDeleted).OrderByDescending(l=>l.LoanDate) .ToListAsync();
            if (loan == null)
            {
                return (IDataResult<IEnumerable<LoanResponseDto>>)new ErrorDataResult<IEnumerable<LoanResponseDto>>("No loans found.");
            }
            var loanResponses = _mapper.Map<IEnumerable<LoanResponseDto>>(loan);
            return (IDataResult<IEnumerable<LoanResponseDto>>)new SuccesDataResult<IEnumerable<LoanResponseDto>>(loanResponses);
        }
        catch (Exception)
        {

            return (IDataResult<IEnumerable<LoanResponseDto>>)new ErrorDataResult<IEnumerable<LoanResponseDto>>("An error occurred while retrieving loans.");
        }
    }

    public async Task<IDataResult<LoanResponseDto>> GetByIdAsync(Guid id)
    {
        try
        {
            var loan = await _loanRepo.GetAsync(l => l.LoanId == id);
            if (loan == null)
            {
                return (IDataResult<LoanResponseDto>)new ErrorDataResult<LoanResponseDto>("Loan not found.");
            }
            var loanResponse = _mapper.Map<LoanResponseDto>(loan);
            return (IDataResult<LoanResponseDto>)new SuccesDataResult<LoanResponseDto>(loanResponse);
        }
        catch (Exception)
        {

            return (IDataResult<LoanResponseDto>)new ErrorDataResult<LoanResponseDto>("An error occurred while retrieving the loan.");
        }
    }

    public async Task<IDataResult<IEnumerable<Loan>>> GetLoansByBookIdAsync(Guid bookId)
    {
        try
        {
            var loan = await _loanRepo.GetAll(l => l.BookId == bookId).OrderByDescending(l => l.LoanDate).ToListAsync();
            if (loan == null)
            {
                return (IDataResult<IEnumerable<Loan>>)new ErrorDataResult<IEnumerable<Loan>>("No loans found for the specified user.");
            }
            return (IDataResult<IEnumerable<Loan>>)new SuccesDataResult<IEnumerable<Loan>>(loan);

        }
        catch (Exception)
        {
            return (IDataResult<IEnumerable<Loan>>)new ErrorDataResult<IEnumerable<Loan>>("An error occurred while retrieving loans for the specified user.");
        }
    }

    public async Task<IDataResult<IEnumerable<Loan>>> GetLoansByUserIdAsync(Guid userId)
    {
        try
        {
            var loan = await _loanRepo.GetAll(l => l.UserId == userId).ToListAsync();
            if (loan == null)
            {
                return (IDataResult<IEnumerable<Loan>>)new ErrorDataResult<IEnumerable<Loan>>("No loans found for the specified user.");
            }
            return (IDataResult<IEnumerable<Loan>>)new SuccesDataResult<IEnumerable<Loan>>(loan);

        }
        catch (Exception)
        {
            return (IDataResult<IEnumerable<Loan>>)new ErrorDataResult<IEnumerable<Loan>>("An error occurred while retrieving loans for the specified user.");
        }
    }

    public async Task<IDataResult<Loan>> LoanBookAsync(Guid bookId, Guid userId)
    {
        try
        {
            var loan = new Loan
            {
                LoanId = Guid.NewGuid(),
                BookId = bookId,
                UserId = userId,
                LoanDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(14),
                IsNotReturned = true,
                IsActive = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            await _loanRepo.AddAsync(loan);
            await _unitOfWork.CommitAsync();
            return (IDataResult<Loan>)new SuccesDataResult<Loan>(loan, "Book loaned successfully.");

        }
        catch (Exception)
        {

            return (IDataResult<Loan>)new ErrorDataResult<Loan>("An error occurred while loaning the book.");
        }
        ;
    }

    public async Task<IResult> RemoveAsync(Guid id)
    {
        try
        {
            var loanTask = _loanRepo.GetAsync(l => l.LoanId == id);
            var loan = await loanTask;
            if (loan == null)
            {
                return new ErrorResult("Loan not found.");
            }
            loan.IsActive = false;
            loan.UpdatedAt = DateTime.Now;
            _loanRepo.Update(loan);
            await _unitOfWork.CommitAsync();
            return new SuccesResult("Loan removed successfully.");
        }
        catch (Exception)
        {
            return new ErrorResult("An error occurred while removing the loan.");
        }
    }

    public async Task<IResult> UpdateAsync(LoanUpdateRequestDto dto)
    {
        try
        {
            var loan = _mapper.Map<Loan>(dto);
            loan.UpdatedAt = DateTime.Now;
            _loanRepo.Update(loan);
            await _unitOfWork.CommitAsync();
            return new SuccesResult("Loan updated successfully.");
        }
        catch (Exception)
        {

            return new ErrorResult("An error occurred while updating the loan.");
        }
    }
}
