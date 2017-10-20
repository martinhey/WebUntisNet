namespace WebUntisNet.Rpc.Types
{
    public class LatestImportTimeRequest : RpcRequest<EmptyRequestParams>
    {
        public override string id => "17";
        public override string method => "namegetLatestImportTime";
    }
}