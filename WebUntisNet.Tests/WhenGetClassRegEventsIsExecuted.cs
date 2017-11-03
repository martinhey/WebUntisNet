using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace WebUntisNet.Tests
{
    public class WhenGetClassRegEventsIsExecuted 
    {
        [Fact(Skip = "insufficient rights")]
        public async Task DataShouldBeReturned()
        {
            var client = new WebUntisClient("https://demo.webuntis.com/WebUntis/jsonrpc.do", "demo_inf", "api", "api", "CLIENT");
            var result = await client.GetClassRegEvents(new DateTime(2017,1,1), new DateTime(2017,12,31), new CancellationToken());

            Assert.NotNull(result);
        }
    }
}