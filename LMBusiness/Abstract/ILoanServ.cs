using Core.Business;
using Core.Utilities.Results;
using LM.Entity.Concrete;
using LM.Entity.DTOs.Loan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Business.Abstract;

public interface ILoanServ : IGenericServ<Loan, LoanResponseDto, LoanCreateRequestDto, LoanUpdateRequestDto, LoanDetailResponseDto>
{
    Task<IDataResult<IEnumerable<Loan>>> GetLoansByBookIdAsync(Guid bookId);
    Task<IDataResult<IEnumerable<Loan>>> GetLoansByUserIdAsync(Guid userId);
    Task<IDataResult<IEnumerable<Loan>>> GetActiveLoansAsync(bool isReturned);
    Task<IDataResult<Loan>> LoanBookAsync(Guid bookId, Guid userId);
    
}
