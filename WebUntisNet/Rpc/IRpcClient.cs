using System;
using System.Threading.Tasks;
using WebUntisNet.Rpc.Types;

namespace WebUntisNet.Rpc
{
    public interface IRpcClient
    {
        Task<AuthenticationResponse> AuthenticateAsync(string schoolName, AuthenticationRequest request);
        Task<RpcResponse> LogoutAsync(LogoutRequest request, string sessionId);
    }

}