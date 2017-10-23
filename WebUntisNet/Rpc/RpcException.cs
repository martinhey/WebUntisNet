using System;
using System.Runtime.Serialization;

namespace WebUntisNet.Rpc
{
    public class RpcException : Exception
    {
        public int ErrorCode { get; private set; }

        public RpcException()
        {
        }

        public RpcException(int code, string message) : this(message)
        {
            ErrorCode = code;
        }


        public RpcException(string message) : base(message)
        {
        }

        public RpcException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RpcException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}