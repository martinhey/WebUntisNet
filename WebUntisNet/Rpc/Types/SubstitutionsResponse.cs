using System.Collections.Generic;

namespace WebUntisNet.Rpc.Types
{
    public class SubstitutionsResponse : RpcResponse<SubstitutionsResponse.ResponseResult>
    {
        public class ResponseResult : List<Substitution>, IRpcResponseResult
        {
        }
    }
}