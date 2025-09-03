using Autofac;
using Core.UnitOfWorks;
using LM.Business.Abstract;
using LM.Business.Concrete;
using LM.DataAccess.Abstract;
using LM.DataAccess.Concrete.EntityFramework;
using LM.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Business.DependencyResolver.AutoFac;

public class AutofacBusinessModule :Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<EfBookRepo>().As<IBookRepo>();
        builder.RegisterType<BookManager>().As<IBookServ>();

        builder.RegisterType<EfUserRepo>().As<IUserRepo>();
        builder.RegisterType<UserManager>().As<IUserServ>();

        builder.RegisterType<EfLoanRepo>().As<ILoanRepo>();
        builder.RegisterType<LoanManager>().As<ILoanServ>();

        builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
    }
}
