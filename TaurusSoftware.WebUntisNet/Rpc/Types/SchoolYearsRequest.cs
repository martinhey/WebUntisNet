namespace TaurusSoftware.WebUntisNet.Rpc.Types
{
    public class SchoolYearsRequest : RpcRequest<SchoolYearsRequest.RequestParams>
    {
        public override string id => "13";
        public override string method => "getSchoolyears";

        public class RequestParams : EmptyRequestParams
        {
        }
    }
}