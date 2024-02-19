namespace CustomExceptions.OrderDetailCustomExceptions
{
    public class OrderDetailArgumentException: Exception
    {
        public OrderDetailArgumentException() : base() { }

        public OrderDetailArgumentException(string message) : base(message) { }

        public OrderDetailArgumentException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
