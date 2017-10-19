namespace WebUntisNet.Rpc.Types
{
    public class TimegridRequest : RpcRequest<EmptyRequestParams>
    {
        public override string id => "10";
        public override string method => "getTimegridUnits";
    }
}