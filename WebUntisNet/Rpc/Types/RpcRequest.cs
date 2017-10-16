namespace WebUntisNet.Rpc.Types
{
    /// <summary>
    /// Base-Class for all Requests
    /// </summary>
    public abstract class RpcRequest
    {
        public RpcRequest()
        {
            @params = new RpcRequestParams();
        }

        public abstract string id { get;  }
        public abstract string method { get;  }
        public virtual RpcRequestParams @params { get;  }
        public string jsonrpc => "2.0";
    }
}