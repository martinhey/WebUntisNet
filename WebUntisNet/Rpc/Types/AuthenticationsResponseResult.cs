namespace WebUntisNet.Rpc.Types
{
    public class AuthenticationsResponseResult : RpcResponseResult
    {
        public string sessionId { get; set; }
        public int personType { get; set; }
        public int personId { get; set; }
    }
}