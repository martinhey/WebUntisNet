using System.Collections.Generic;

namespace WebUntisNet.Rpc.Types
{
    public class ClassregEventsResponse : RpcResponse<ClassregEventsResponse.ResponseResult>
    {
        public class ResponseResult : List<ClassregEvent>, IRpcResponseResult
        {
        }
    }
}