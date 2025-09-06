using LM.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.DataAccess.Configurations
{
    internal class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.Property(l => l.LoanDate).IsRequired();
            builder.Property(l => l.ReturnDate).IsRequired(false);
            builder.Property(l => l.IsReturned).IsRequired().HasDefaultValue(false);
            builder.HasOne(l => l.Book)
        .WithMany(b => b.Loans)
        .HasForeignKey(l => l.BookId)
        .HasPrincipalKey(b => b.Id);

            builder.Property(l => l.IsReturned).IsRequired().HasDefaultValue(false);
            builder.HasOne(l => l.User)
        .WithMany(b => b.Loans)
        .HasForeignKey(l => l.UserId)
        .HasPrincipalKey(b => b.Id);
        }
    }

}
