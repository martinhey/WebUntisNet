using System.Collections.Generic;

namespace TaurusSoftware.WebUntisNet.Rpc.Types
{
    public class SchoolYearsResponse : RpcResponse<SchoolYearsResponse.ResponseResult>
    {
        public class ResponseResult : List<SchoolYear>, IRpcResponseResult
        {
        }
    }
}