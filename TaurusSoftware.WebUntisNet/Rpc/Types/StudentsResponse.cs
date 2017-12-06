using System.Collections.Generic;

namespace TaurusSoftware.WebUntisNet.Rpc.Types
{
    public class StudentsResponse : RpcResponse<StudentsResponse.ResponseResult>
    {
        public class ResponseResult : List<Student>, IRpcResponseResult
        {
        }
    }
}