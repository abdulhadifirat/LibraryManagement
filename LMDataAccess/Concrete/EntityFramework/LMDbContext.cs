using LM.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace LM.DataAccess.Concrete.EntityFramework;

// Ensure LMDbContext has a public parameterless constructor:
//public sealed class LMDbContext : DbContext
//{
//    public LMDbContext() : base()
//    {
//    }

//    public LMDbContext(DbContextOptions options) : base(options)
//    {
//    }

//    // ... existing code ...
//}

public class LMDbContext : DbContext
{
    public LMDbContext(DbContextOptions<LMDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=FIRAT\\SQLEXPRESS;Initial Catalog=LibraryManagementDB;Integrated Security=True;Trust Server Certificate=True;");
        }
    }

    public LMDbContext() : base()
    {
    }

    public DbSet<Book> Books { get; set; }
}

