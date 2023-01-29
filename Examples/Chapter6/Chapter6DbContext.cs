using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EfInAction.Examples.Chapter6
{
    public class Chapter6DbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql("Host=localhost;Database=ef-action-6;Username=postgres;Password=pass")
                .LogTo(Console.WriteLine, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*  Shadow property */
            modelBuilder.Entity<Book>()
                .Property<string>("LastUpdateBy");
        }
    }
}