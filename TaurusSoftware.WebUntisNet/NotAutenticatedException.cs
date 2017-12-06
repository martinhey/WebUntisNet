using System;
using System.Runtime.Serialization;

namespace TaurusSoftware.WebUntisNet
{
    public class NotAutenticatedException : Exception
    {
        public NotAutenticatedException()
        {
        }

        public NotAutenticatedException(string message) : base(message)
        {
        }

        public NotAutenticatedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotAutenticatedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
