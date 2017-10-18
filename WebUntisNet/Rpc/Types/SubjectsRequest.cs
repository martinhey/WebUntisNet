namespace WebUntisNet.Rpc.Types
{
    public class SubjectsRequest : RpcRequest<EmptyRequestParams>
    {
        public override string id => "ID";

        public override string method => "getSubjects";
    }
}