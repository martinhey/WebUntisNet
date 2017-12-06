using System.Collections.Generic;

namespace TaurusSoftware.WebUntisNet.Rpc.Types
{
    public class ClassregEventsResponse : RpcResponse<ClassregEventsResponse.ResponseResult>
    {
        public class ResponseResult : List<ClassregEvent>, IRpcResponseResult
        {
        }
    }
}