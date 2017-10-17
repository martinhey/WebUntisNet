namespace WebUntisNet.Rpc.Types
{
    public class TeachersRequest : RpcRequest<EmptyRequestParams>
    {
        public override string id => "ID";
        public override string method => "getTeachers";
    }
}
