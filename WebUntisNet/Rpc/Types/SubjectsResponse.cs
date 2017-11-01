using System.Collections.Generic;

namespace WebUntisNet.Rpc.Types
{
    public class SubjectsResponse : RpcResponse<SubjectsResponse.ResponseResult>
    {
        public class ResponseResult : List<Subject>, IRpcResponseResult
        {
        }
    }
}