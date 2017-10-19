namespace WebUntisNet.Rpc.Types
{
    public class LogoutRequest : RpcRequest<EmptyRequestParams>
    {
        public override string id => "2";

        public override string method => "logout";
    }
}