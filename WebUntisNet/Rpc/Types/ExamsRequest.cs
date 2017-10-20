namespace WebUntisNet.Rpc.Types
{
    public class ExamsRequest : RpcRequest<ExamsRequestParams>
    {
        public override string id => "21";
        public override string method => "getExams";
    }
}