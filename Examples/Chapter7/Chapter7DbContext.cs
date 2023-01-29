using EfInAction.Examples.Chapter7.ConfigRelationshipsByConvention;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EfInAction.Examples.Chapter7
{
    public class Chapter7DbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql("Host=localhost;Database=ef-action-7;Username=postgres;Password=pass")
                .LogTo(Console.WriteLine, LogLevel.Information);
        }
    }
}