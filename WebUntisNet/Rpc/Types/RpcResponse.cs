namespace WebUntisNet.Rpc.Types
{
    /// <summary>
    /// Base-Class for all Responses
    /// </summary>
    public abstract class RpcResponse<T> : IRpcResponse where T : RpcResponseResult, new()
    {
        public string id { get; set; }
        public T result { get; set; }
        public string jsonrpc { get; set; }
        public Error error;
    }
}