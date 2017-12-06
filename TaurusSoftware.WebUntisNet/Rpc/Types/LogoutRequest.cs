namespace TaurusSoftware.WebUntisNet.Rpc.Types
{
    public class LogoutRequest : RpcRequest<LogoutRequest.RequestParams>
    {
        public override string id => "2";

        public override string method => "logout";

        public class RequestParams : EmptyRequestParams
        {
        }
    }
}