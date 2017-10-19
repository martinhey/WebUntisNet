namespace WebUntisNet.Rpc.Types
{
    public class SubjectsRequest : RpcRequest<EmptyRequestParams>
    {
        public override string id => "6";
        public override string method => "getSubjects";
    }
}