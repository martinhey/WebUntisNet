namespace WebUntisNet.Rpc.Types
{
    public class StatusDataResponse : RpcResponse<StatusDataResponse.ResponseResult>
    {
        public class ResponseResult : StatusData, IRpcResponseResult
        {
        }
    }
}