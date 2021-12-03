using Xunit;
using System.Threading.Tasks;
using System.Net.Http;

namespace hw6Tests
{
	public class Tests
	{
		[Theory]
		[InlineData("1","add", "1", "2.0")]
		[InlineData("10","add", "30", "40.0")]
		[InlineData("0", "add", "0", "0.0")]
		[InlineData("1","subtract", "1", "0.0")]
		[InlineData("10","subtract", "9", "1.0")]
		[InlineData("0", "subtract", "0", "0.0")]
		[InlineData("1","multiply", "1", "1.0")]
		[InlineData("10","multiply", "9", "90.0")]
		[InlineData("0", "multiply", "0", "0.0")]
		[InlineData("1","divide", "1", "1.0")]
		[InlineData("10","divide", "5", "2.0")]
		[InlineData("0", "divide", "3", "0.0")]
		public static async Task Test(string v1,string operation, string v2, string expected)
		{
			var httpClient = new HttpClient();
			var response = await httpClient.GetAsync($"http://localhost:5000/{operation}?v1={v1}&v2={v2}");
			var result = await response.Content.ReadAsStringAsync();
			Assert.Equal(expected, result);
		}
		
		
	}
} 