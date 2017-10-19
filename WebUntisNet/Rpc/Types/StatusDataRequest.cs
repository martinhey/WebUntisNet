namespace WebUntisNet.Rpc.Types
{
    public class StatusDataRequest : RpcRequest<EmptyRequestParams>
    {
        public override string id => "11";
        public override string method => "getStatusData";
    }
}