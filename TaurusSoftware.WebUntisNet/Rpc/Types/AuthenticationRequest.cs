namespace TaurusSoftware.WebUntisNet.Rpc.Types
{
    public class AuthenticationRequest : RpcRequest<AuthenticationRequest.RequestParams>
    {
        public AuthenticationRequest(string user, string password, string client)
        {
            @params.user = user;
            @params.password = password;
            @params.client = client;
        }

        public override string id => "1";
        public override string method => "authenticate";

        public class RequestParams : IRpcRequestParams
        {
            public string user = "ANDROID";
            public string password;
            public string client;
        }
    }
}