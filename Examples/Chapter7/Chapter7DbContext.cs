using EfInAction.Examples.Chapter7.ConfigRelationshipsByConvention;
using EfInAction.Examples.Chapter7.OwnedTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EfInAction.Examples.Chapter7
{
    public class Chapter7DbContext : DbContext
    {
        /*  ConfigRelationshipsByConvention */
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        /* OwnedTypes */
        public DbSet<OrderInfo> OrderInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql("Host=localhost;Database=ef-action-7;Username=postgres;Password=pass")
                .LogTo(Console.WriteLine, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderInfo>()
                .OwnsOne(p => p.BillingAddress);

            modelBuilder.Entity<OrderInfo>()
                .OwnsOne(p => p.DeliveryAddress);
        }
    }
}