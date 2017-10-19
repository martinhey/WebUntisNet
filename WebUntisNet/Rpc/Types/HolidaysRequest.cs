namespace WebUntisNet.Rpc.Types
{
    public class HolidaysRequest : RpcRequest<EmptyRequestParams>
    {
        public override string id => "9";
        public override string method => "getHolidays";
    }
}