using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace TaurusSoftware.WebUntisNet.Tests
{
    public class WhenGetExamTypesIsExecuted 
    {
     
        [Fact(Skip = "no user with sufficient rights")]
        public async Task DataShouldBeReturned()
        {
            var client = new WebUntisClient("https://demo.webuntis.com/WebUntis/jsonrpc.do", "demo_inf", "Lehrer", "", "CLIENT");
            /*var result =*/ await client.GetExamTypesAsync(new CancellationToken());

            //Assert.NotNull(result);
        }

    }
}