namespace CustomExceptions.DishCustomExceptions
{
    public class DishArgumentException : Exception
    {
        public DishArgumentException() : base() { }

        public DishArgumentException(string message) : base(message) { }

        public DishArgumentException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
