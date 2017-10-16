namespace WebUntisNet.Rpc.Types
{
    /// <summary>
    /// Base-Class for all Requests
    /// </summary>
    public abstract class RpcRequest
    {
        public abstract string id { get;  }
        public abstract string method { get;  }
        public RpcRequestParams @params { get;  }
        public string jsonrpc => "2.0";
    }
}