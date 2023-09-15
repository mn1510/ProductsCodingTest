using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using CodingTest;
using CodingTest.DataModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using static System.Net.WebRequestMethods;

namespace CodingTestUnitTests
{
    public class ProductsControllerIntegrationTests
    {
        private readonly HttpClient _client;
        private string _testToken;
        public ProductsControllerIntegrationTests()
        {
            // Arrange: Create a test web application using the WebApplicationFactory
            var webApplicationFactory = new WebApplicationFactory<global::Program>();
            _client = webApplicationFactory.CreateClient();
            _testToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.MurbVg_eomKe-Pi7j8AIcuoAeEb3fDBqhT4HkYdMXg0";
        }

        [Test]
        public async Task GetProductsWithoutToken_Returns_UnAuthorized()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "");

            var response = await _client.GetAsync("/api/products");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        }


        [Test]
        public async Task GetProductsByColourWithoutToken_Returns_UnAuthorized()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "");

            var response = await _client.GetAsync("/api/products/Red");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        }

        [Test]
        public async Task GetProducts_Returns_OkResult()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this._testToken);

            var response = await _client.GetAsync("/api/products");

            response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task GetProductByColour_Returns_OkResult()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this._testToken);

            var response = await _client.GetAsync("/api/products/Red");

            response.EnsureSuccessStatusCode();
        }
    }
}
