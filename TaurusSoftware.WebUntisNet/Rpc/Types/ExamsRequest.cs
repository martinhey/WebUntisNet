namespace TaurusSoftware.WebUntisNet.Rpc.Types
{
    public class ExamsRequest : RpcRequest<ExamsRequest.RequestParams>
    {
        public ExamsRequest()
        {
            
        }

        public ExamsRequest(int examTypeId, int startDate, int endDate)
        {
            @params.startDate = startDate;
            @params.endDate = endDate;
            @params.examTypeId = examTypeId;
        }

        public override string id => "21";
        public override string method => "getExams";


        public class RequestParams : IRpcRequestParams
        {
            public int examTypeId { get; set; }
            public int startDate { get; set; }
            public int endDate { get; set; }
        }
    }
}