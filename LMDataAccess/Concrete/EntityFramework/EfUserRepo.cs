using Core.DataAccess;
using LM.DataAccess.Abstract;
using LM.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.DataAccess.Concrete.EntityFramework
{
    public class EfUserRepo : EfGenericRepo<User, LMDbContext>, IUserRepo
    {
        public EfUserRepo(LMDbContext context) : base(context)
        {
        }
    }
    
}
