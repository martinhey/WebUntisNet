namespace TaurusSoftware.WebUntisNet.Rpc.Types
{
    public class PersonIdResponse : RpcResponse<PersonIdResponse.ResponseResult>
    {
        public class ResponseResult : Number, IRpcResponseResult
        {
        }
    }
}