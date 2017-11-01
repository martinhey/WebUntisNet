namespace WebUntisNet.Rpc.Types
{
    public class ExamTypesRequest : RpcRequest<ExamTypesRequest.RequestParams>
    {
        public override string id => "22";
        public override string method => "getExamTypes";

        public class RequestParams : EmptyRequestParams
        {
        }
    }
}