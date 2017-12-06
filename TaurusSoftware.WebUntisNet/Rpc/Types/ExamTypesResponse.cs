using System.Collections.Generic;

namespace TaurusSoftware.WebUntisNet.Rpc.Types
{
    public class ExamTypesResponse : RpcResponse<ExamTypesResponse.ResponseResult>
    {
        public class ResponseResult : List<ExamType>, IRpcResponseResult
        {
        }
    }
}