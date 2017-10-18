namespace WebUntisNet.Rpc.Types
{
    public class StatusDataRequest : RpcRequest<EmptyRequestParams>
    {
        public override string id => "ID";
        public override string method => "getStatusData";
    }
}