using System;
using System.Threading.Tasks;
using WebUntisNet.Rpc;
using WebUntisNet.Rpc.Types;

namespace WebUntisNet
{
    public class UntisClient : IDisposable
    {
        private const string DefaultClientName = "WebUntisNet";
        private readonly IRpcClient _rpcClient;

        private string _sessionId;
        private bool _disposed = false; // To detect redundant calls

        public PersonType? PersonType { get; private set; }
        public int? PersonId { get; set; }

        public UntisClient(string serviceEndpoint, string schoolName, string userName, string password): this(serviceEndpoint, schoolName, userName, password, DefaultClientName)
        {
        }

        public UntisClient(string serviceEndpoint, string schoolName, string userName, string password, string clientName)
        {
            _rpcClient = new RpcClient(serviceEndpoint);
            
            AuthenticateAsync(serviceEndpoint, schoolName, userName, clientName).GetAwaiter().GetResult();
        }

        public async Task AuthenticateAsync(string schoolName, string userName, string password, string clientName)
        {
            var request = new AuthenticationRequest(userName, password, clientName);
            var result = await _rpcClient.AuthenticateAsync(schoolName, request);

            EnsureSuccess(result);

            _sessionId = result.result.sessionId;
            PersonType = (PersonType) result.result.personType;
            PersonId = result.result.personId;
        }

        public async Task LogoutAsync()
        {
            var request = new LogoutRequest();
            var result = await _rpcClient.LogoutAsync(request, _sessionId);

            EnsureSuccess(result);

            _sessionId = null;
            PersonType = null;
            PersonId = null;
        }

        private void EnsureSuccess(RpcResponse response)
        {
            string errorMsg = response.error?.message;
            if (!string.IsNullOrEmpty(errorMsg))
            {
                throw new RpcException(errorMsg);
            }
        }

        public bool IsLoggedIn => !string.IsNullOrEmpty(_sessionId);
        

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (IsLoggedIn)
                    {
                        LogoutAsync().GetAwaiter().GetResult();
                    }
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
