namespace WebUntisNet.Rpc.Types
{
    public class SchoolYearsRequest : RpcRequest<EmptyRequestParams>
    {
        public override string id => "ID";
        public override string method => "getSchoolyears";
    }
}