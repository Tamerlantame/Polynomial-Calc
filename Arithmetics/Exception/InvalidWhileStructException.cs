using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetics
{
    public class InvalidWhileStructException : Exception
    {
        public InvalidWhileStructException()
        {
        }

        public InvalidWhileStructException(string message) : base(message)
        {
        }

        public InvalidWhileStructException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidWhileStructException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
