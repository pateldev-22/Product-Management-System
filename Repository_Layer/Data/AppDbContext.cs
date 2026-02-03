using Microsoft.EntityFrameworkCore;
using Repository_Layer.Entity;


namespace Repository_Layer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);  

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Laptop",
                    Price = 999.99m,
                    StockQuantity = 10,
                    CreatedAt = new DateTime(2026, 2, 1, 10, 0, 0) 
                },
                new Product
                {
                    Id = 2,
                    Name = "Mouse",
                    Price = 29.99m,
                    StockQuantity = 50,
                    CreatedAt = new DateTime(2026, 2, 1, 10, 0, 0) 
                }
            );
        }
    }

}

