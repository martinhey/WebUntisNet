using System.Collections.Generic;

namespace TaurusSoftware.WebUntisNet.Rpc.Types
{
    public class RoomsResponse : RpcResponse<RoomsResponse.ResponseResult>
    {
        public class ResponseResult : List<Room>, IRpcResponseResult
        {
        }
    }
}