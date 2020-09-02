using System.Collections.Generic;
using Products.API.Model;

namespace Products.API.Service
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
        Product Add(Product product);
        Product Edit(Product product);
        Product Delete(int id);
        
    }
}
