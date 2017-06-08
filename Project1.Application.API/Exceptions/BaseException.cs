using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Project1.Application.API.Exceptions
{
    [Serializable]
    public abstract class BaseException : Exception
    {
        private const string DefaultMessage = "Logic error.";

        protected BaseException()
            : base(DefaultMessage)
        {
        }

        protected BaseException(string message)
            : base(message)
        {
        }

        protected BaseException(string message, Exception ex)
            : base(message, ex)
        {
        }

        protected BaseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
