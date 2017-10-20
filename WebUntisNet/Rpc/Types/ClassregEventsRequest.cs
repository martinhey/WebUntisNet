namespace WebUntisNet.Rpc.Types
{
    public class ClassregEventsRequest : RpcRequest<ClassregEventsRequestParams>
    {
        public override string id => "20";
        public override string method => "getClassregEvents";
    }
}