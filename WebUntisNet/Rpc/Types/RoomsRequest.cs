namespace WebUntisNet.Rpc.Types
{
    public class RoomsRequest : RpcRequest<RoomsRequest.RequestParams>
    {
        public override string id => "7";

        public override string method => "getRooms";

        public class RequestParams : EmptyRequestParams
        {
        }
    }
}