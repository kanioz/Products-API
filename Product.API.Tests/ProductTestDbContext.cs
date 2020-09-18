using System.IO;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Products.API.Data;
using Products.API.Model;


namespace Products.API.Tests
{
    public class ProductTestDbContext : ProductDbContext
    {
        public ProductTestDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedData<User>(modelBuilder, "../../../data/users.json");
            SeedData<Product>(modelBuilder, "../../../data/products.json");
        }

        private void SeedData<T>(ModelBuilder modelBuilder, string file) where T : class
        {
            using var reader = new StreamReader(file);
            var json = reader.ReadToEnd();
            var data = JsonConvert.DeserializeObject<T[]>(json);
            modelBuilder.Entity<T>().HasData(data);
        }
    }
}
