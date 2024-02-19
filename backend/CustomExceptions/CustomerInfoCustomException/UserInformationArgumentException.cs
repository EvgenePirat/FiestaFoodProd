

namespace CustomExceptions.CustomerInfoCustomException
{
    public class CustomerInfoArgumentException : Exception
    {
        public CustomerInfoArgumentException() : base() { }

        public CustomerInfoArgumentException(string message) : base(message) { }

        public CustomerInfoArgumentException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
