namespace WebUntisNet.Rpc.Types
{
    public class DepartmentsRequest : RpcRequest<EmptyRequestParams>
    {
        public override string id => "8";
        public override string method => "getDepartments";
    }
}