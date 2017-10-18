namespace WebUntisNet.Rpc.Types
{
    public class CurrentSchoolYearRequest : RpcRequest<EmptyRequestParams>
    {
        public override string id => "ID";
        public override string method => "getCurrentSchoolyear";
    }
}