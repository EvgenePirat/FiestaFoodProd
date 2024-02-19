using System.Net;

namespace WebApi.Utilities.Middleware.ExceptionsHandlers
{
    public record ExceptionResponse(HttpStatusCode StatusCode, string Description);
}
