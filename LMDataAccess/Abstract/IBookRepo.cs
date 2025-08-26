using Core.DataAccess;
using LM.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.DataAccess.Abstract
{
    public interface IBookRepo : IGenericRepo<Book>
    {
    }
}
