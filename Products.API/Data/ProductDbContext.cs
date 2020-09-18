using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Products.API.Model;

namespace Products.API.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new List<User>
            {
                new User
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    UserName = "test",
                    Password = "pass",
                    Token = ""
                }
            });

            modelBuilder.Entity<Product>().HasData(new List<Product>
            {
                new Product
                {
                    Id= 1,
                    Name = "Test Ürünü A",
                    Price = 12,
                    Stock= 1000
                },
                new Product
                {
                    Id= 2,
                    Name = "Test Ürünü B",
                    Price = 10,
                    Stock= 1500
                },
                new Product
                {
                    Id= 3,
                    Name = "Test Ürünü C",
                    Price = 8,
                    Stock= 750
                }
            });
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
