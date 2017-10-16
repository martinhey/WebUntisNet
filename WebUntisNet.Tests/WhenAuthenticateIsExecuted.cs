using NUnit.Framework;
using System.Threading.Tasks;
using WebUntisNet.Rpc;
using WebUntisNet.Rpc.Types;

namespace WebUntisNet.Tests
{
    public class WhenAuthenticateIsExecuted
    {
        [Test]
        public async Task DataShouldBeReturned()
        {
            var client = new RpcClient("https://demo.webuntis.com/WebUntis/jsonrpc.do");
            var request = new AuthenticationRequest()
            {
                @params = new AuthenticationRequestParams()
                {
                    client = "CLIENT",
                    user = "Schueler",
                    password = ""
                }
            };
            var result = await client.AuthenticateAsync("demo_inf", request);

            Assert.IsNull(result.error);
        }
    }
}
