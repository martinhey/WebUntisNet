namespace TaurusSoftware.WebUntisNet.Rpc.Types
{
    public class LatestImportTimeRequest : RpcRequest<LatestImportTimeRequest.RequestParams>
    {
        public override string id => "17";
        public override string method => "getLatestImportTime";

        public class RequestParams : EmptyRequestParams
        {
        }
    }
}