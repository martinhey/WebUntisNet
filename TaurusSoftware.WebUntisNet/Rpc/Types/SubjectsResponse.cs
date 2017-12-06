using System.Collections.Generic;

namespace TaurusSoftware.WebUntisNet.Rpc.Types
{
    public class SubjectsResponse : RpcResponse<SubjectsResponse.ResponseResult>
    {
        public class ResponseResult : List<Subject>, IRpcResponseResult
        {
        }
    }
}