namespace WebUntisNet.Rpc.Types
{
    /// <summary>
    /// Base-Class for all Requests
    /// </summary>
    public class RpcRequest
    {
        public string id;
        public string method;
        public readonly string jsonrpc = "2.0";
    }
}