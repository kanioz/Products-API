using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Products.API.Data;
using Products.API.Model;

namespace Products.API.Service
{
    public class ProductService: IProductService
    {
        private readonly ProductDbContext _dbContext;
        public ProductService(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Product> GetProducts()
        {
            return _dbContext.Products.ToList();
        }

        public Product GetProduct(int id)
        {
            return _dbContext.Products.Find(id);
        }

        public Product Add(Product product)
        {
            var entity = _dbContext.Products.Add(product).Entity;
            _dbContext.SaveChanges();
            return entity;
        }

        public Product Edit(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Detached;
            _dbContext.SaveChanges();
            return product;
        }

        public Product Delete(int id)
        {
            var entity = _dbContext.Products.Find(id);
            var deleted = _dbContext.Products.Remove(entity).Entity;
            return deleted;
        }
    }
}
