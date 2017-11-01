using System.Collections.Generic;

namespace WebUntisNet.Rpc.Types
{
    public class HolidaysResponse : RpcResponse<HolidaysResponse.ResponseResult>
    {
        public class ResponseResult : List<Holiday>, IRpcResponseResult
        {
        }
    }
}