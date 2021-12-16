using System.Net.Http;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using hw6;
using hw8;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;

namespace hw12
{
    public class HostBuilderFSharp : WebApplicationFactory<hw6.App.Startup>
    {
        protected override IHostBuilder CreateHostBuilder()
            => Host
                .CreateDefaultBuilder()
                .ConfigureWebHostDefaults(a => a
                    .UseStartup<hw6.App.Startup>()
                    .UseTestServer());
    }

    public class HostBuilderCSharp : WebApplicationFactory<hw8.Startup>
    {
        protected override IHostBuilder CreateHostBuilder()
            => Host
                .CreateDefaultBuilder()
                .ConfigureWebHostDefaults(a => a
                    .UseStartup<hw8.Startup>()
                    .UseTestServer());
    }

    [MinColumn]
    [MaxColumn]
    [MedianColumn]
    public class BenchmarkTests
    {
        private HttpClient CSharpClient;
        private HttpClient FSharpClient;

        [GlobalSetup]
        public void GlobalSetUp()
        {
            CSharpClient = new HostBuilderCSharp().CreateClient();
            FSharpClient = new HostBuilderFSharp().CreateClient();
        }

        [Benchmark]
        public async Task AddInCSharp()
        {
            await SendRequestCSharp("5", "add", "8");
        }

        [Benchmark]
        public async Task AddInFSharp()
        {
            await SendRequestFSharp("5", "add", "8");
        }

        [Benchmark]
        public async Task SubtractInCSharp()
        {
            await SendRequestCSharp("10", "-", "1");
        }

        [Benchmark]
        public async Task SubtractInFSharp()
        {
            await SendRequestFSharp("10", "subtract", "1");
        }

        [Benchmark]
        public async Task MultiplyInCSharp()
        {
            await SendRequestCSharp("5", "*", "8");
        }

        [Benchmark]
        public async Task MultiplyInFSharp()
        {
            await SendRequestFSharp("5", "multiply", "8");
        }

        [Benchmark]
        public async Task DivideInCSharp()
        {
            await SendRequestCSharp("10", "/", "2");
        }

        [Benchmark]
        public async Task DivideInFSharp()
        {
            await SendRequestFSharp("10", "divide", "2");
        }

        private async Task SendRequestFSharp(string v1, string operation, string v2)
        {
            await FSharpClient.GetAsync($"http://localhost:5000/{operation}?v1={v1}&v2={v2}");
        }

        private async Task SendRequestCSharp(string v1, string operation, string v2)
        {
            await CSharpClient.GetAsync($"calculator/calculate?val1={v1}&operation={operation}&val2={v2}");
        }
    }
}