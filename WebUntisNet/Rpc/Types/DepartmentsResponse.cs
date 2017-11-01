using System.Collections.Generic;

namespace WebUntisNet.Rpc.Types
{
    public class DepartmentsResponse : RpcResponse<DepartmentsResponse.ResponseResult>
    {
        public class ResponseResult : List<Department>, IRpcResponseResult
        {
        }
    }
}