using System.Collections.Generic;

namespace TaurusSoftware.WebUntisNet.Rpc.Types
{
    public class TeachersResponse : RpcResponse<TeachersResponse.ResponseResult>
    {
        public class ResponseResult : List<Teacher>, IRpcResponseResult
        {
        }
    }
}