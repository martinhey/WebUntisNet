namespace WebUntisNet.Rpc.Types
{
    public class HolidaysRequest : RpcRequest<HolidaysRequest.RequestParams>
    {
        public override string id => "9";
        public override string method => "getHolidays";

        public class RequestParams : EmptyRequestParams
        {
        }
    }
}