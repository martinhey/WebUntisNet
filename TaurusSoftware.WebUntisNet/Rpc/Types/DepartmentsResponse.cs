using System.Collections.Generic;

namespace TaurusSoftware.WebUntisNet.Rpc.Types
{
    public class DepartmentsResponse : RpcResponse<DepartmentsResponse.ResponseResult>
    {
        public class ResponseResult : List<Department>, IRpcResponseResult
        {
        }
    }
}