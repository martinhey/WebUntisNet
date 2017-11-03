using System;

namespace WebUntisNet.Rpc.Types
{
    public class ClassregEventsRequest : RpcRequest<ClassregEventsRequest.RequestParams>
    {
        public ClassregEventsRequest(int startDate, int endDate)
        {
            @params.startDate = startDate;
            @params.endDate = endDate;
        }

        public override string id => "20";
        public override string method => "getClassregEvents";

        public class RequestParams : IRpcRequestParams
        {
            public int startDate { get; set; }
            public int endDate { get; set; }
        }
    }
}