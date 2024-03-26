using System.Net;
using CustomExceptions.CategoryCustomExceptions;
using CustomExceptions.DishCustomExceptions;
using CustomExceptions.IngredientCustomException;
using CustomExceptions.OrderCustomExceptions;
using CustomExceptions.OrderDetailCustomExceptions;
using CustomExceptions.UserCustomException;

namespace WebApi.Utilities.Middleware.ExceptionsHandlers
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, "An unexpected error occurred.");

            var response = exception switch
            {
                ApplicationException _ => new ExceptionResponse(HttpStatusCode.BadRequest, "Application exception occurred."),
                KeyNotFoundException _ => new ExceptionResponse(HttpStatusCode.NotFound, "The request key not found."),
                UnauthorizedAccessException _ => new ExceptionResponse(HttpStatusCode.Unauthorized, "Unauthorized."),
                UserArgumentException _ => new ExceptionResponse(HttpStatusCode.Conflict, exception.Message),
                IngredientArgumentException _ => new ExceptionResponse(HttpStatusCode.BadRequest, exception.Message),
                DishArgumentException _ => new ExceptionResponse(HttpStatusCode.BadRequest, exception.Message),
                CategoryArgumentException _ => new ExceptionResponse(HttpStatusCode.BadRequest, exception.Message),
                OperationCanceledException _ => new ExceptionResponse(HttpStatusCode.RequestTimeout, exception.Message),
                OrderArgumentException _ => new ExceptionResponse(HttpStatusCode.RequestTimeout, exception.Message),
                OrderDetailArgumentException _ => new ExceptionResponse(HttpStatusCode.RequestTimeout, exception.Message),
                _ => new ExceptionResponse(HttpStatusCode.InternalServerError, "Internal server error. Please retry later.")
            }; ;

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)response.StatusCode;
            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
