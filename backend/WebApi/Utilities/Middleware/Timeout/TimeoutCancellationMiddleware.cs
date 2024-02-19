namespace WebApi.Utilities.Middleware.Timeout
{
    public class TimeoutCancellationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TimeSpan _timeout;

        public TimeoutCancellationMiddleware(RequestDelegate next, TimeoutCancellationMiddlewareOptions options)
        {
            _next = next;
            _timeout = options.Timeout;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //Create a new CancellationTokenSource and set a time-out
            using var timeoutCancellationTokenSource = new CancellationTokenSource();
            timeoutCancellationTokenSource.CancelAfter(_timeout);

            //Create a new CancellationTokenSource linking the timeoutCancellationToken and ASP.NET's RequestAborted CancellationToken
            using var combinedCancellationTokenSource =
                CancellationTokenSource
                    .CreateLinkedTokenSource(timeoutCancellationTokenSource.Token, context.RequestAborted);

            //Override the RequestAborted CancellationToken with our combined CancellationToken
            context.RequestAborted = combinedCancellationTokenSource.Token;

            await _next(context);
        }
    }
}
