namespace WebUntisNet.Rpc.Types
{
    /// <summary>
    /// Base-Class for all Responses
    /// </summary>
    public class RpcResponse
    {
        public string id;
        public object result;
        public readonly string jsonrpc = "2.0";

        public Error error;
    }
}