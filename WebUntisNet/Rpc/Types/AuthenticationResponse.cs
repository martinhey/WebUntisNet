namespace WebUntisNet.Rpc.Types
{
    public class AuthenticationResponse : RpcResponse<AuthenticationResponse.ResponseResult>
    {
        public class ResponseResult : IRpcResponseResult
        {
            public string sessionId { get; set; }
            public int personType { get; set; }
            public int personId { get; set; }
        }
    }
}