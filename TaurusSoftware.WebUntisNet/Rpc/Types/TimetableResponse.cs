using System.Collections.Generic;

namespace TaurusSoftware.WebUntisNet.Rpc.Types
{
    public class TimetableResponse : RpcResponse<TimetableResponse.ResponseResult>
    {
        public class ResponseResult : List<Period>, IRpcResponseResult
        {
        }
    }
}