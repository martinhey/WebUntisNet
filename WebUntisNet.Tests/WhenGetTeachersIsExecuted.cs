using System;
using System.Threading.Tasks;
using WebUntisNet.Rpc;
using WebUntisNet.Rpc.Types;
using WebUntisNet.Net;
using Xunit;

namespace WebUntisNet.Tests
{
    public class WhenGetTeachersIsExecuted : IDisposable
    {
        private RpcClient _client;
        private string _sessionId;

        public WhenGetTeachersIsExecuted()
        {
            _client = new RpcClient(new HttpClient(), "https://demo.webuntis.com/WebUntis/jsonrpc.do");
            var authRequest = new AuthenticationRequest("api", "api", "CLIENT");
            var authResponse = _client.AuthenticateAsync("demo_inf", authRequest).GetAwaiter().GetResult();
            _sessionId = authResponse.result.sessionId;

        }
        

        [Fact(Skip = "no user with sufficient rights")]
        public async Task DataShouldBeReturned()
        {
            var request = new TeachersRequest();
            var response = await _client.GetTeachersAsync(request, _sessionId);

            Assert.Null(response.error);
        }

        #region IDisposable Support
        private bool disposed = false; 

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _client.LogoutAsync(new LogoutRequest(), _sessionId);
                }

              

                disposed = true;
            }
        }

        public void Dispose()
        {
            
            Dispose(true);
        }
        #endregion
    }
}