namespace WebUntisNet.Rpc.Types
{
    public class AuthenticationRequest : RpcRequest<AuthenticationRequestParams>
    {
        public AuthenticationRequest(string user, string password, string client)
        {
            @params.user = user;
            @params.password = password;
            @params.client = client;
        }

        public override string id => "ID";
        public override string method => "authenticate";
    }
}