namespace WebUntisNet.Rpc.Types
{
    public class HolidaysRequest : RpcRequest<EmptyRequestParams>
    {
        public override string id => "ID";
        public override string method => "getHolidays";
    }
}