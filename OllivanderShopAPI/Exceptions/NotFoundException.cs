using Microsoft.AspNetCore.Mvc;
using OllivandersShopAPI.Exceptions.Base;
using System.Net;

namespace OllivandersShopAPI.Exceptions
{
    public class NotFoundException : OllivandersShopApiExceptionBase
    {
        public NotFoundException(string message, string instancePath) : base(message, instancePath)
        {
            ProblemDetails.Type = @"https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
            ProblemDetails.Title = "The object you're looking for doesn't exist";
            ProblemDetails.Status = (int)HttpStatusCode.NotFound;
            ProblemDetails.Detail = message;
        }
    }
}
