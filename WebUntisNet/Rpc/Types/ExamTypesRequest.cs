namespace WebUntisNet.Rpc.Types
{
    public class ExamTypesRequest : RpcRequest<EmptyRequestParams>
    {
        public override string id => "22";
        public override string method => "getExamTypes";
    }
}