using System;
using System.Runtime.Serialization;

namespace WebUntisNet.Rpc
{
    public class RpcException : Exception
    {
        public RpcException()
        {
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