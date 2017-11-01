using System.Collections.Generic;

namespace WebUntisNet.Rpc.Types
{
    public class SchoolYearsResponse : RpcResponse<SchoolYearsResponse.ResponseResult>
    {
        public class ResponseResult : List<SchoolYear>, IRpcResponseResult
        {
        }
    }
}