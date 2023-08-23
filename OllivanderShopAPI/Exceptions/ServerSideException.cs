using OllivandersShopAPI.Exceptions.Base;
using System.Net;

namespace OllivandersShopAPI.Exceptions
{
    public class ServerSideException : OllivandersShopApiExceptionBase
    {
        public ServerSideException(string message, string instancePath) : base(message, instancePath)
        {
            ProblemDetails.Type = typeof(ServerSideException).Name;
            ProblemDetails.Title = "Unexpected problems on the server side. Try again a little later";
            ProblemDetails.Status = (int)HttpStatusCode.InternalServerError;
            ProblemDetails.Detail = message;
        }
    }
}
