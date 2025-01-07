using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HopitalConsoleMatmut.Exception
{
    public class HopitalPersistenceException : HopitalException
    {
        public HopitalPersistenceException()
        {
        }

        public HopitalPersistenceException(string? message) : base(message)
        {
        }

        public HopitalPersistenceException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }

        protected HopitalPersistenceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
