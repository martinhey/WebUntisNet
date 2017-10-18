using System.Threading.Tasks;
using NUnit.Framework;
using WebUntisNet.Rpc;
using WebUntisNet.Rpc.Types;
using WebUntisNet.Net;

namespace WebUntisNet.Tests
{
    public class WhenGetTeachersIsExecuted
    {
        private RpcClient _client;
        private string _sessionId;

        [SetUp]
        public void BeforeTest()
        {
            _client = new RpcClient(new HttpClient(), "https://demo.webuntis.com/WebUntis/jsonrpc.do");
            var authRequest = new AuthenticationRequest("Raumadmin", "", "CLIENT");
            var authResponse = _client.AuthenticateAsync("demo_kb", authRequest).GetAwaiter().GetResult();
            _sessionId = authResponse.result.sessionId;
        }

        [TearDown]
        public void AfterTest()
        {
            _client.LogoutAsync(new LogoutRequest(), _sessionId);
        }

        [Test]
        public async Task DataShouldBeReturned()
        {
            var request = new TeachersRequest();
            var response = await _client.GetTeachersAsync(request, _sessionId);

            Assert.IsNull(response.error);
        }
    }
}