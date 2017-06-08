using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Project1.Application.API.Exceptions
{
    [Serializable]
    public class AuthorizationException : BaseException
    {
        private const string DefaultMessage = "Current user is not authorized for this operation.";

        public AuthorizationException()
            : base(DefaultMessage)
        {
        }

        public AuthorizationException(string message, Exception inner)
            : base(DefaultMessage + "\n" + message, inner)
        {
        }

        protected AuthorizationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
