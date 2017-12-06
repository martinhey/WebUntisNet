namespace TaurusSoftware.WebUntisNet.Rpc.Types
{
    public class SimpleTimetableRequest : RpcRequest<SimpleTimetableRequest.RequestParams>
    {
        public SimpleTimetableRequest(int type, int id, int? startDate = null, int? endDate = null)
        {
            @params.type = type;
            @params.id = id;
            @params.startDate = startDate;
            @params.endDate = endDate;
        }

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