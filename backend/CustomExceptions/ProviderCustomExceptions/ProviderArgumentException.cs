namespace CustomExceptions.ProviderCustomExceptions
{
    public class ProviderArgumentException : Exception
    {
        public ProviderArgumentException() : base() { }

        public ProviderArgumentException(string message) : base(message) { }

        public ProviderArgumentException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
