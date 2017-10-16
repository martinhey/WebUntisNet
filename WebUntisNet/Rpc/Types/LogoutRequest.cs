namespace WebUntisNet.Rpc.Types
{
    public class LogoutRequest : RpcRequest
    {
        public override string id => "ID";

        public override string method => "logout";
    }
}