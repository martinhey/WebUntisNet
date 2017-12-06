using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace TaurusSoftware.WebUntisNet.Tests
{
    public class WhenGetLatestImportTimeIsExecuted 
    {
        [Fact]
        public async Task DataShouldBeReturned()
        {
            var client = new WebUntisClient("https://demo.webuntis.com/WebUntis/jsonrpc.do", "demo_inf", "Lehrer", "", "CLIENT");
            var result = await client.GetLatestImportTimeAsync(new CancellationToken());

            Assert.True(true);
        }
    }
}