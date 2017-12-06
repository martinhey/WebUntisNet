using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace TaurusSoftware.WebUntisNet.Tests
{
    public class WhenGetTeachersIsExecuted 
    {
        [Fact(Skip = "no user with sufficient rights")]
        public async Task DataShouldBeReturned()
        {
            var client = new WebUntisClient("https://demo.webuntis.com/WebUntis/jsonrpc.do", "demo_inf", "Lehrer", "", "CLIENT");
            var result = await client.GetTeachersAsync(new CancellationToken());

            Assert.False(true);
        }
    }
}