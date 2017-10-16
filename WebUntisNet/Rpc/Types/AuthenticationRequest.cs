namespace WebUntisNet.Rpc.Types
{
    public class AuthenticationRequest : RpcRequest
    {
        public AuthenticationRequest()
        {
            @params = new AuthenticationRequestParams();
        }

        public AuthenticationRequest(string user, string password, string client) : this()
        {
            @params.user = user;
            @params.password = password;
            @params.client = client;
        }


        public override string id => "ID";
        public override string method => "authenticate";
        public new AuthenticationRequestParams @params { get; }

    }
}