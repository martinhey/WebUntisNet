namespace WebUntisNet.Rpc.Types
{
    public class DepartmentsRequest : RpcRequest<EmptyRequestParams>
    {
        public override string id => "ID";
        public override string method => "getDepartments";
    }
}