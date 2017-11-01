using System.Collections.Generic;

namespace WebUntisNet.Rpc.Types
{
    public class RoomsResponse : RpcResponse<RoomsResponse.ResponseResult>
    {
        public class ResponseResult : List<Room>, IRpcResponseResult
        {
        }
    }
}