namespace WebUntisNet.Rpc.Types
{
    /// <summary>
    /// Base-Class for all Responses
    /// </summary>
    public abstract class RpcResponse
    {
        public string id { get; set; }
        public virtual RpcResponseResult result { get; set; }
        public string jsonrpc { get; set; }

        public Error error;
    }

    public abstract class RpcResponseResult
    {
        
    }
}