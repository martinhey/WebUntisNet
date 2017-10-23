using System;
using System.Threading.Tasks;
using Xunit;

namespace WebUntisNet.Tests
{
    public class WhenGetExamsIsExecuted 
    {

        [Fact(Skip = "no user with sufficient rights")]
        public async Task DataShouldBeReturned()
        {
            var client = new WebUntisClient("https://demo.webuntis.com/WebUntis/jsonrpc.do", "demo_inf", "Lehrer", "", "CLIENT");
            var result = await client.GetExamsAsync(1, new DateTime(2017, 1, 1), new DateTime(2017, 12, 31));

            Assert.False(true);
        }
    }
}