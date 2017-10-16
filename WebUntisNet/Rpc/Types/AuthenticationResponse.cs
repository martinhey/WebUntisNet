namespace WebUntisNet.Rpc.Types
{
    public class AuthenticationResponse : RpcResponse
    {
        public new AuthenticationsResponseResult result { get; set; }
    }

}