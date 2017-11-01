namespace WebUntisNet.Rpc.Types
{
    public class TimegridRequest : RpcRequest<TimegridRequest.RequestParams>
    {
        public override string id => "10";
        public override string method => "getTimegridUnits";

        public class RequestParams : EmptyRequestParams
        {
        }
    }
}