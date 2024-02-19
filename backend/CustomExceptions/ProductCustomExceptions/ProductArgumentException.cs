using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.CustomExceptions
{
    public class ProductArgumentException : Exception
    {
        public ProductArgumentException() : base() { }

        public ProductArgumentException(string message) : base(message) { }

        public ProductArgumentException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
