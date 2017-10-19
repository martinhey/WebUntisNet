namespace WebUntisNet.Rpc.Types
{
    public class StudentsRequest : RpcRequest<EmptyRequestParams>
    {
        public override string id => "4";
        public override string method => "getStudents";
    }
}