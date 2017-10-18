using NUnit.Framework;
using System.Threading.Tasks;
using WebUntisNet.Net;
using WebUntisNet.Rpc;
using WebUntisNet.Rpc.Types;

namespace WebUntisNet.Tests
{
    public class WhenAuthenticateIsExecuted
    {
        [Test]
        public async Task DataShouldBeReturned()
        {
            var client = new RpcClient(new HttpClient(), "https://demo.webuntis.com/WebUntis/jsonrpc.do");
            var request = new AuthenticationRequest("Schueler", "", "CLIENT");
            var response = await client.AuthenticateAsync("demo_inf", request);

            Assert.IsNull(response.error);
            Assert.IsNotEmpty(response.result.sessionId);
            Assert.IsTrue(response.result.personId > 0);
            Assert.IsTrue(response.result.personType > 0);
        }
    }
}
