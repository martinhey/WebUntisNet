namespace WebUntisNet.Rpc.Types
{
    public class StatusDataRequest : RpcRequest<StatusDataRequest.RequestParams>
    {
        public override string id => "11";
        public override string method => "getStatusData";

        public class RequestParams : EmptyRequestParams
        {
        }
    }
}