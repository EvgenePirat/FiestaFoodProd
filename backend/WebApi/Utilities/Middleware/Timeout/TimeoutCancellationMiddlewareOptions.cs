namespace WebApi.Utilities.Middleware.Timeout
{
    public class TimeoutCancellationMiddlewareOptions
    {
        public TimeSpan Timeout { get; set; }

        public TimeoutCancellationMiddlewareOptions(TimeSpan timeout)
        {
            Timeout = timeout;
        }
    }
}
