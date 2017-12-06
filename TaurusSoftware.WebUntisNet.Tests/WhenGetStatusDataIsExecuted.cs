using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace TaurusSoftware.WebUntisNet.Tests
{
    public class WhenGetStatusDataIsExecuted 
    {
        [Fact]
        public async Task DataShouldBeReturned()
        {
            var client = new WebUntisClient("https://demo.webuntis.com/WebUntis/jsonrpc.do", "demo_inf", "Lehrer", "", "CLIENT");
            var result = await client.GetStatusDataAsync(new CancellationToken());

            Assert.NotNull(result);
        }
    }
}