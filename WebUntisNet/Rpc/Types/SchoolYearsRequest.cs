namespace WebUntisNet.Rpc.Types
{
    public class SchoolYearsRequest : RpcRequest<EmptyRequestParams>
    {
        public override string id => "13";
        public override string method => "getSchoolyears";
    }
}