using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions.IngredientCustomException
{
    public class IngredientArgumentException : Exception
    {
        public IngredientArgumentException() : base() { }

        public IngredientArgumentException(string message) : base(message) { }

        public IngredientArgumentException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
