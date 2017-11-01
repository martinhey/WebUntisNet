namespace WebUntisNet.Rpc.Types
{
    public class CurrentSchoolYearRequest : RpcRequest<CurrentSchoolYearRequest.RequestParams>
    {
        public override string id => "12";
        public override string method => "getCurrentSchoolyear";

        public class RequestParams : EmptyRequestParams
        {
        }
    }
}