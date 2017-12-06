using System.Threading.Tasks;
using TaurusSoftware.WebUntisNet.Net;
using TaurusSoftware.WebUntisNet.Rpc;
using TaurusSoftware.WebUntisNet.Rpc.Types;
using Xunit;

namespace TaurusSoftware.WebUntisNet.Tests
{
    public class WhenAuthenticateIsExecuted
    {
        [Fact]
        public async Task DataShouldBeReturned()
        {
            var client = new RpcClient(new HttpClient(), "https://demo.webuntis.com/WebUntis/jsonrpc.do");
            var request = new AuthenticationRequest("Schueler", "", "CLIENT");
            var response = await client.AuthenticateAsync("demo_inf", request);

            Assert.Null(response.error);
            Assert.NotEmpty(response.result.sessionId);
            Assert.True(response.result.personId > 0);
            Assert.True(response.result.personType > 0);
        }
    }
}
