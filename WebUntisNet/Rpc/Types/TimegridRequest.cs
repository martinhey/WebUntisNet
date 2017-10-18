namespace WebUntisNet.Rpc.Types
{
    public class TimegridRequest : RpcRequest<EmptyRequestParams>
    {
        public override string id => "ID";
        public override string method => "getTimegridUnits";
    }
}