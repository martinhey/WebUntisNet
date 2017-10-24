using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace WebUntisNet.Tests
{
    public class WhenGetStudentsIsExecuted 
    {
        [Fact(Skip = "no user with sufficient rights")]
        public async Task DataShouldBeReturned()
        {
            var client = new WebUntisClient("https://demo.webuntis.com/WebUntis/jsonrpc.do", "demo_inf", "Lehrer", "", "CLIENT");
            var result = await client.GetStudentsAsync(new CancellationToken());

            Assert.False(true);
        }
    }
}