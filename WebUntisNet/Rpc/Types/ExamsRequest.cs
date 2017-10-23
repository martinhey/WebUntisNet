namespace WebUntisNet.Rpc.Types
{
    public class ExamsRequest : RpcRequest<ExamsRequestParams>
    {
        public ExamsRequest() : base()
        {
            
        }

        public ExamsRequest(int examTypeId, int startDate, int endDate) : base()
        {
            @params.startDate = startDate;
            @params.endDate = endDate;
            @params.examTypeId = examTypeId;
        }

        public override string id => "21";
        public override string method => "getExams";
    }
}