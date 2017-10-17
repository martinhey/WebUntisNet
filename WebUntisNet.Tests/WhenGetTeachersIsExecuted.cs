using System.Threading.Tasks;
using NUnit.Framework;
using WebUntisNet.Rpc;
using WebUntisNet.Rpc.Types;

namespace WebUntisNet.Tests
{
    public class WhenGetTeachersIsExecuted
    {
        [Test]
        public async Task DataShouldBeReturned()
        {
            var client = new RpcClient("https://demo.webuntis.com/WebUntis/jsonrpc.do");
            var authRequest = new AuthenticationRequest("Schueler", "", "CLIENT");
            var authResponse = await client.AuthenticateAsync("demo_inf", authRequest);

            var request = new TeachersRequest();
            var response = await client.GetTeachersAsync(request, authResponse.result.sessionId);

            Assert.IsNull(response.error);
        }
    }
}