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
    internal class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(b => b.Author).IsRequired().HasMaxLength(100);
            builder.Property(b => b.Title).IsRequired().HasMaxLength(200);
            builder.Property(b => b.PublishedDate).IsRequired();
            builder.Property(b => b.Description).HasMaxLength(1000);
            builder.Property(b => b.StockStatus).IsRequired().HasDefaultValue(true);
        }
    }
}
