namespace CustomExceptions.CategoryCustomExceptions
{
    public class CategoryArgumentException : Exception
    {
        public CategoryArgumentException() : base() { }

        public CategoryArgumentException(string message) : base(message) { }

        public CategoryArgumentException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
