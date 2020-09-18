using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Products.API.ViewModel;
using Xunit;

namespace Products.API.Tests
{
    public class ControllerTestsBase : IClassFixture<InMemoryWebApplicationFactory<Startup>>
    {
        private InMemoryWebApplicationFactory<Startup> _factory;
        protected HttpClient Client;
        public ControllerTestsBase(InMemoryWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            Client = factory.CreateClient();

            var httpContent = new StringContent(JsonConvert.SerializeObject(new AuthenticateRequest { UserName = "test", Password = "pass" }), Encoding.UTF8, "application/json");
            var authResponse = Client.PostAsync("/api/auth/token", httpContent);
            var response = JsonConvert.DeserializeObject<AuthenticateResponse>(authResponse.Result.Content.ReadAsStringAsync().Result);
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", response.Token);
        }
    }
}
