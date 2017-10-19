namespace WebUntisNet.Rpc.Types
{
    public class CurrentSchoolYearRequest : RpcRequest<EmptyRequestParams>
    {
        public override string id => "12";
        public override string method => "getCurrentSchoolyear";
    }
}