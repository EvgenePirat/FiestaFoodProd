namespace CustomExceptions.BrandCustomExceptions
{
    public class BrandArgumentException : Exception
    {
        public BrandArgumentException() : base() { }

        public BrandArgumentException(string message) : base(message) { }

        public BrandArgumentException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
