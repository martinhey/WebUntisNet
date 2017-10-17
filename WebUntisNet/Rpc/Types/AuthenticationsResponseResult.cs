namespace WebUntisNet.Rpc.Types
{
    public class AuthenticationsResponseResult : IRpcResponseResult
    {
        public string sessionId { get; set; }
        public int personType { get; set; }
        public int personId { get; set; }
    }
}