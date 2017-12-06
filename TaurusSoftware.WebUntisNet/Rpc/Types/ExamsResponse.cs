using System.Collections.Generic;

namespace TaurusSoftware.WebUntisNet.Rpc.Types
{
    public class ExamsResponse : RpcResponse<ExamsResponse.ResponseResult>
    {
        public class ResponseResult : List<Exam>, IRpcResponseResult
        {
        }
    }
}