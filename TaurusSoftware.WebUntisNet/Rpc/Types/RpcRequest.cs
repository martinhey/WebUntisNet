namespace TaurusSoftware.WebUntisNet.Rpc.Types
{
    /// <summary>
    /// Base-Class for all Requests
    /// </summary>
    public abstract class RpcRequest<T> : IRpcRequest where T : IRpcRequestParams, new()
    {
        public RpcRequest()
        {
            @params = new T();
        }

        public abstract string id { get;  }
        public abstract string method { get;  }
        public T @params { get;  }
        public string jsonrpc => "2.0";
    }
}