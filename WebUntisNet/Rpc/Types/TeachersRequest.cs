namespace WebUntisNet.Rpc.Types
{
    public class TeachersRequest : RpcRequest<EmptyRequestParams>
    {
        public override string id => "3";
        public override string method => "getTeachers";
    }
}
