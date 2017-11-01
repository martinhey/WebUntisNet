namespace WebUntisNet.Rpc.Types
{
    public class DepartmentsRequest : RpcRequest<DepartmentsRequest.RequestParams>
    {
        public override string id => "8";
        public override string method => "getDepartments";

        public class RequestParams : EmptyRequestParams
        {
        }
    }
}