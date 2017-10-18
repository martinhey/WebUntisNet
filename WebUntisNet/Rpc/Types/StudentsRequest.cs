namespace WebUntisNet.Rpc.Types
{
    public class StudentsRequest : RpcRequest<EmptyRequestParams>
    {
        public override string id => "ID";
        public override string method => "getStudents";
    }
}