using OllivandersShopAPI.Exceptions.Base;
using System.Net;

namespace OllivandersShopAPI.Exceptions
{
    public class ServerSideException : OllivandersShopApiExceptionBase
    {
        public ServerSideException(string message, string instancePath) : base(message, instancePath)
        {
            ProblemDetails.Type = @"https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1";
            ProblemDetails.Title = "Unexpected problems on the server side. Try again a little later";
            ProblemDetails.Status = (int)HttpStatusCode.InternalServerError;
            ProblemDetails.Detail = message;
        }
    }
}
