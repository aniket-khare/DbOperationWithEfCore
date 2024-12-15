using Microsoft.EntityFrameworkCore;

namespace DbOperationsWithEFCoreApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasData(
                new Currency() { Id=1, Title="INR", Description="Indian INR"},
                new Currency() { Id=2, Title="Dollar", Description= "American Dollar" },
                new Currency() { Id=3, Title="Euro", Description= "European Euro" },
                new Currency() { Id=4, Title="Dinar", Description= "Dubai Dinar" }
                );

            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = 1, Title = "Hindi", Description = "Hindi" },
                new Language() { Id = 2, Title = "Tamil", Description = "Tamil" },
                new Language() { Id = 3, Title = "Punjabi", Description = "Punjabi" },
                new Language() { Id = 4, Title = "Urdu", Description = "Urdu" }
                );

            modelBuilder.Entity<BookPrice>().HasData(
                new BookPrice() { Id = 1, BookId = 233, Amount = 3000, CurrencyId= 1},
                new BookPrice() { Id = 2, BookId = 234, Amount = 2000, CurrencyId = 3 },
                new BookPrice() { Id = 3, BookId = 235, Amount = 5000, CurrencyId = 4 },
                new BookPrice() { Id = 4, BookId = 236, Amount = 600, CurrencyId = 2}
                );
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<BookPrice> BookPrices { get; set; }
        public DbSet<Currency> Currencies { get; set; }
    }
}
