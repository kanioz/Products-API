using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Products.API.Model;
using Xunit;

namespace Products.API.Tests
{
    public class ProductsControllerTest : IClassFixture<InMemoryWebApplicationFactory<Startup>>
    {

        private InMemoryWebApplicationFactory<Startup> _factory;

        public ProductsControllerTest(InMemoryWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task product_api_connection_testAsync()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/products");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task post_request_test()
        {
            var product = new Product
            {
                Name = "TestName",
                Price = 5,
                Stock = 1500
            };

            var client = _factory.CreateClient();
            var httpContent = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/products", httpContent);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.NotNull(response.Headers.Location);
        }
        [Fact]
        public async Task put_request_test()
        {
            var client = _factory.CreateClient();
            var request = new Product { Name = "X", Price = 100, Stock = 10 };
            var httpContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response = await client.PutAsync("api/products/3", httpContent);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
