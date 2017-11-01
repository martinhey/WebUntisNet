using System.Collections.Generic;

namespace WebUntisNet.Rpc.Types
{
    public class TimetableResponse : RpcResponse<TimetableResponse.ResponseResult>
    {
        public class ResponseResult : List<Period>, IRpcResponseResult
        {
        }
    }
}