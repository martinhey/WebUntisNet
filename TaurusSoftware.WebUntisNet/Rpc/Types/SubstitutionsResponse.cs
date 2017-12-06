using System.Collections.Generic;

namespace TaurusSoftware.WebUntisNet.Rpc.Types
{
    public class SubstitutionsResponse : RpcResponse<SubstitutionsResponse.ResponseResult>
    {
        public class ResponseResult : List<Substitution>, IRpcResponseResult
        {
        }
    }
}