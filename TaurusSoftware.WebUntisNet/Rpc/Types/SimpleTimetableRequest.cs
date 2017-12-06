namespace TaurusSoftware.WebUntisNet.Rpc.Types
{
    public class SimpleTimetableRequest : RpcRequest<SimpleTimetableRequest.RequestParams>
    {
        public override string id => "ID";
        public override string method => "getTimetable";

        public class RequestParams : IRpcRequestParams
        {
            public int id { get; set; }
            public int type { get; set; }
            public int? startDate { get; set; }
            public int? endDate { get; set; }
        }
    }
}