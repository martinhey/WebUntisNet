namespace WebUntisNet.Rpc.Types
{
    public class RoomsRequest : RpcRequest<EmptyRequestParams>
    {
        public override string id => "ID";

        public override string method => "getRooms";
    }
}