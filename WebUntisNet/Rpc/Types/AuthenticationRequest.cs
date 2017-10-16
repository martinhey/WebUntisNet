namespace WebUntisNet.Rpc.Types
{
    public class AuthenticationRequest : RpcRequest
    {
        public new string id = "ID";
        public new readonly string method = "authenticate";
        public AuthenticationRequestParams @params;

    }

    public class AuthenticationRequestParams
    {
        public string user = "ANDROID";
        public string password;
        public string client;
    }
}