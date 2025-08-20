using Core.Entities;
using LM.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public class EfGenericRepo<TEntity, TContext> : IGenericRepo<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
    {
    }
}
