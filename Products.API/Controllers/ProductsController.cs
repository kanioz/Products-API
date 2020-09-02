using Microsoft.AspNetCore.Mvc;
using Products.API.Model;
using Products.API.Service;

namespace Products.API.Controllers
{
    [Route("api/Products")]
    [ApiController]
    public class ProductsController :  ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products =  _service.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            return Ok(_service.GetProduct(id));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product product)
        {
            var existingProduct = _service.GetProduct(id);
            if (existingProduct == null)
            {
                return BadRequest($"{id} id'li eleman yok.");
            }
            product.Id = id;
            return Ok(_service.Edit(product));

        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var newProduct = _service.Add(product);
            return CreatedAtAction(nameof(GetProductById), new { id = newProduct.Id }, null);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            if (_service.GetProduct(id) == null)
            {
                return BadRequest($"{id} id'li eleman yok.");
            }
            return Ok(_service.Delete(id));
        }


    }
}
