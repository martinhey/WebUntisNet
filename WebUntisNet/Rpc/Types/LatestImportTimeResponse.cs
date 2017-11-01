namespace WebUntisNet.Rpc.Types
{
    public class LatestImportTimeResponse : RpcResponse<LatestImportTimeResponse.ResponseResult>
    {
        public class ResponseResult : Number, IRpcResponseResult
        {
        }
    }
}