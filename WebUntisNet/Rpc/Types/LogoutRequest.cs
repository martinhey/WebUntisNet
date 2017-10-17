namespace WebUntisNet.Rpc.Types
{
    public class LogoutRequest : RpcRequest<EmptyRequestParams>
    {
        public override string id => "ID";

        public override string method => "logout";
    }
}