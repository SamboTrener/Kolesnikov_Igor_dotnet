using System.Globalization;
using System.Net;
using System.Threading.Tasks;
using hw8;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace hw8Tests
{
    public class IntegrationTests
    {
        public class IntegrationTests1
            : IClassFixture<WebApplicationFactory<Startup>>
        {
            private readonly WebApplicationFactory<Startup> factory;

            public IntegrationTests1(WebApplicationFactory<Startup> factory)
            {
                this.factory = factory;
            }
        
            [Theory]
            [InlineData("1", "add", "x", "WrongArgFormat")]
            [InlineData("x", "add", "1", "WrongArgFormat")]
            [InlineData("2", "oleg", "1", "WrongOperationFormat")]
            public async Task ErrorTests(string v1, string op, string v2, string expectedError)
            {
                var client = factory.CreateClient();
                var response = await client.GetAsync($"calculator/calculate?val1={v1}&operation={op}&val2={v2}");
                var result = await response.Content.ReadAsStringAsync();
                Assert.Equal(expectedError, result);
            }

            [Theory]
            [InlineData("2", "add", "3", 5)]
            [InlineData("2", "-", "1", 1)]
            [InlineData("2", "*", "5", 10)]
            [InlineData("20", "/", "4", 5)]
            public async Task PositiveTests(string v1, string op, string v2, double expected)
            {
                var client = factory.CreateClient();
                var response = await client.GetAsync($"calculator/calculate?val1={v1}&operation={op}&val2={v2}");
                var result = await response.Content.ReadAsStringAsync();
                Assert.Equal(expected, double.Parse(result));
            }
        }
    }
}