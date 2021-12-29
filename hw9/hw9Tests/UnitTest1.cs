using System;
using System.Globalization;
using System.Threading.Tasks;
using hw9;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace hw9Tests
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
            [InlineData("2%2b3*3", 11)]
            [InlineData("2-1%2b6", 7)]
            [InlineData("2*5-1", 9)]
            [InlineData("20/4%2b3", 8)]
            [InlineData("(2%2b3)/12*7%2b8*9", 74.91666666666667)]
            [InlineData("23-20*4-(22/3-5)", -59.333333333333336)]
            public async Task PositiveTests(string input, double expected)
            {
                var client = factory.CreateClient();
                var response = await client.GetAsync($"calculator/calculate?input={input}");
                var result = await response.Content.ReadAsStringAsync();
                Assert.Equal(expected, double.Parse(result,CultureInfo.InvariantCulture));
            }
        }
    }
}