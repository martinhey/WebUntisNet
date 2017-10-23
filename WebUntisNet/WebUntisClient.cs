using System;
using System.Threading;
using System.Threading.Tasks;
using WebUntisNet.Net;
using WebUntisNet.Rpc;
using WebUntisNet.Rpc.Types;

namespace WebUntisNet
{
    public class WebUntisClient : IDisposable
    {
        private const string DefaultClientName = "WebUntisNet";
        private readonly IRpcClient _rpcClient;

        private string _sessionId;
        private bool _disposed = false; // To detect redundant calls

        /// <summary>
        /// Gets the person type of the user who's logged in.
        /// </summary>
        public PersonType? PersonType { get; private set; }

        /// <summary>
        /// Gets the person id of the user who's logged in.
        /// </summary>
        public int? PersonId { get; private set; }

        public WebUntisClient(string serviceEndpoint, string schoolName, string userName, string password) : this(serviceEndpoint, schoolName, userName, password, DefaultClientName)
        {
        }

        public WebUntisClient(string serviceEndpoint, string schoolName, string userName, string password, string clientName)
        {
            _rpcClient = new RpcClient(new HttpClient(), serviceEndpoint);

            AuthenticateAsync(schoolName, userName, password, clientName).GetAwaiter().GetResult();
        }

        public async Task AuthenticateAsync(string schoolName, string userName, string password, string clientName, CancellationToken token = default(CancellationToken))
        {
            var request = new AuthenticationRequest(userName, password, clientName);
            var result = await _rpcClient.AuthenticateAsync(schoolName, request);

            if (result.error?.code != null)
            {
                throw new RpcException(result.error.code, result.error.message);
            }

            _sessionId = result.result.sessionId;
            PersonType = (PersonType)result.result.personType;
            PersonId = result.result.personId;
        }

        /// <summary>
        /// Ends the current session.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task LogoutAsync(CancellationToken token = default(CancellationToken))
        {
            if (IsLoggedIn)
            {
                var request = new LogoutRequest();
                var result = await _rpcClient.LogoutAsync(request, _sessionId);

                if (!string.IsNullOrEmpty(result?.error?.message))
                {
                    throw new RpcException(result.error.message);
                }
            }

            _sessionId = null;
            PersonType = null;
            PersonId = null;
        }

        public async Task GetExamsAsync(int examTypeId, DateTime startDate, DateTime endDate, CancellationToken token = default(CancellationToken))
        {
            if (!IsLoggedIn)
            {
                throw new NotAutenticatedException();
            }

            var request = new ExamsRequest(examTypeId, startDate.ToApiDate(), endDate.ToApiDate());
            await _rpcClient.GetExamsAsync(request, _sessionId, token);
        }

        /// <summary>
        /// Returns whether the user is currently logged in (session exists) or not.
        /// </summary>
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
