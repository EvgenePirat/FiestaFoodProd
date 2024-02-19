namespace CustomExceptions.FileCustomExceptions
{
    public class FileArgumentException : Exception
    {
        public FileArgumentException() : base() { }

        public FileArgumentException(string message) : base(message) { }

        public FileArgumentException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
