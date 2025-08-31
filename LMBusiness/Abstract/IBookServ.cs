using Core.Business;
using Core.Utilities.Results;
using LM.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Business.Abstract;

public interface IBookServ : IGenericServ<Book>
{
    Task<IDataResult<IEnumerable<Book>>> GetBooksByAuthorAsync(string author);
    Task<IDataResult<IEnumerable<Book>>> GetBooksByTitleAsync(string title);
    Task<IDataResult<IEnumerable<Book>>> GetAvailableBooksAsync(bool stockStatus);
    Task<IDataResult<IEnumerable<Book>>> GetBooksPublishedAfterAsync(DateTime publishedDate);


}
