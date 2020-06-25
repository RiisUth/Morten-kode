using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class NoMoreProductsException : Exception
    {
        public NoMoreProductsException() { }
        public NoMoreProductsException(string message) : base(message) { }
        public NoMoreProductsException(string message, Exception inner) : base(message, inner) { }
        protected NoMoreProductsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
