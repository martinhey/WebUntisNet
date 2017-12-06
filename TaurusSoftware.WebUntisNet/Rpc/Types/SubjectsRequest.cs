namespace TaurusSoftware.WebUntisNet.Rpc.Types
{
    public class SubjectsRequest : RpcRequest<SubjectsRequest.RequestParams>
    {
        public override string id => "6";
        public override string method => "getSubjects";

        public class RequestParams : EmptyRequestParams
        {
        }
    }
}