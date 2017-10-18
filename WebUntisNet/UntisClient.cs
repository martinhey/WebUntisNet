using System;
using System.Threading.Tasks;
using WebUntisNet.Net;
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
        public int? PersonId { get; private set; }

        public UntisClient(string serviceEndpoint, string schoolName, string userName, string password): this(serviceEndpoint, schoolName, userName, password, DefaultClientName)
        {
        }

        public UntisClient(string serviceEndpoint, string schoolName, string userName, string password, string clientName)
        {
            _rpcClient = new RpcClient(new HttpClient(), serviceEndpoint);
            
            AuthenticateAsync(schoolName, userName, password, clientName).GetAwaiter().GetResult();
        }

        public async Task AuthenticateAsync(string schoolName, string userName, string password, string clientName)
        {
            var request = new AuthenticationRequest(userName, password, clientName);
            var result = await _rpcClient.AuthenticateAsync(schoolName, request);

            if (!string.IsNullOrEmpty(result?.error?.message))
            {
                throw new RpcException(result.error.message);
            }

            _sessionId = result.result.sessionId;
            PersonType = (PersonType) result.result.personType;
            PersonId = result.result.personId;
        }

        public async Task LogoutAsync()
        {
            var request = new LogoutRequest();
            var result = await _rpcClient.LogoutAsync(request, _sessionId);

            if (!string.IsNullOrEmpty(result?.error?.message))
            {
                throw new RpcException(result.error.message);
            }

            _sessionId = null;
            PersonType = null;
            PersonId = null;
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
