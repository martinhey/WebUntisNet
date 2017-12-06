using System.Collections.Generic;

namespace TaurusSoftware.WebUntisNet.Rpc.Types
{
    public class TimegridResponse : RpcResponse<TimegridResponse.ResponseResult>
    {
        public class ResponseResult : List<TimegridItem>, IRpcResponseResult
        {
        }
    }
}