using Core.DataAccess;
using LM.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LM.DataAccess.Abstract
{
    public interface IUserRepo : IGenericRepo<User>
    {
      
    }
}
