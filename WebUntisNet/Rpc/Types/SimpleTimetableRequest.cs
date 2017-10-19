namespace WebUntisNet.Rpc.Types
{
    public class SimpleTimetableRequest : RpcRequest<SimpleTimetableRequestParams>
    {
        public override string id => "ID";
        public override string method => "getTimetable";
    }
}