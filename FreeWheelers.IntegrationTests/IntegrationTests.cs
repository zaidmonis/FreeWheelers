using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace FreeWheelers.IntegrationTests
{
    public class IntegrationTests : IClassFixture<TestFixture<Startup>>
    {
        private readonly HttpClient _httpClient;

        public IntegrationTests(TestFixture<Startup> fixture)
        {
            _httpClient = fixture.Client;
        }
        
        [Fact]
        public async Task TestGetValuesAsync()
        {
            var request = "/api/value";

            var response = await _httpClient.GetAsync(request);

            response.EnsureSuccessStatusCode();
            var data = response.Content.ReadAsStringAsync().Result;
            Assert.Equal("[\"a\",\"b\"]", data);
        }
    }
}