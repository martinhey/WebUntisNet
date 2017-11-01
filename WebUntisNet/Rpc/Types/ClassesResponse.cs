using System.Collections.Generic;

namespace WebUntisNet.Rpc.Types
{
    public class ClassesResponse : RpcResponse<ClassesResponse.ResponseResult>
    {

        public class ResponseResult : List<Class>, IRpcResponseResult
        {
        }
    }
}