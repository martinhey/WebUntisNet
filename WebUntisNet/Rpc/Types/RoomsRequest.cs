namespace WebUntisNet.Rpc.Types
{
    public class RoomsRequest : RpcRequest<EmptyRequestParams>
    {
        public override string id => "7";

        public override string method => "getRooms";
    }
}