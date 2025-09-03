using Microsoft.EntityFrameworkCore;
using store_API.Models;
using System.Diagnostics.Metrics;

namespace store_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Seed Categories  Data
            modelBuilder.Entity<Category>().HasData(
                  new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Books" },
                new Category { Id = 3, Name = "Clothing" }
            );

            modelBuilder.Entity<Product>().HasData(
                   new Product { Id = 1, Name = "Laptop", Description = "Dell XPS 13", Price = 1200, CategoryId = 1 },
                new Product { Id = 2, Name = "Smartphone", Description = "Samsung Galaxy S23", Price = 900, CategoryId = 1 },
                new Product { Id = 3, Name = "Novel", Description = "The Alchemist", Price = 15, CategoryId = 2 },
                new Product { Id = 4, Name = "T-Shirt", Description = "Cotton White T-Shirt", Price = 20, CategoryId = 3 }
                );
        }
        }
}
