using AutoMapper;
using Core.UnitOfWorks;
using Core.Utilities.Results;
using LM.Business.Abstract;
using LM.DataAccess.Abstract;
using LM.Entity.Concrete;
using LM.Entity.DTOs.Loan;
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

    public Task<IDataResult<LoanResponseDto>> AddAsync(LoanCreateRequestDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<IDataResult<IEnumerable<Loan>>> GetActiveLoansAsync(bool isReturned)
    {
        throw new NotImplementedException();
    }

    public Task<IDataResult<IEnumerable<LoanResponseDto>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IDataResult<LoanResponseDto>> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IDataResult<IEnumerable<Loan>>> GetLoansByBookIdAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<IDataResult<IEnumerable<Loan>>> GetLoansByUserIdAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<IDataResult<Loan>> LoanBookAsync(Guid bookId, Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<IResult> RemoveAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IDataResult<Loan>> ReturnBookAsync(Guid loanId)
    {
        throw new NotImplementedException();
    }

    public Task<IResult> UpdateAsync(LoanUpdateRequestDto dto)
    {
        throw new NotImplementedException();
    }
}
