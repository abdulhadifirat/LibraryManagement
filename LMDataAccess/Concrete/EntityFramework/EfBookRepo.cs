using Core.DataAccess;
using LM.DataAccess.Abstract;
using LM.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.DataAccess.Concrete.EntityFramework;

public class EfBookRepo : EfGenericRepo<Book, LMDbContext>, IBookRepo
{
    public EfBookRepo(LMDbContext context) : base(context)
    {
    }
}


