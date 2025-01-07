using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HopitalConsoleMatmut.Exception
{
    public class HopitalException : ApplicationException
    {
        public HopitalException()
        {
        }

        public HopitalException(string? message) : base(message)
        {
        }

        public HopitalException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }

        protected HopitalException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
