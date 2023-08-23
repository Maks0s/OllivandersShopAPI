using Microsoft.AspNetCore.Mvc;
using OllivandersShopAPI.Exceptions.Base;
using System.Net;

namespace OllivandersShopAPI.Exceptions
{
    public class NotFoundException : OllivandersShopApiExceptionBase
    {
        public NotFoundException(string message, string instancePath) : base(message, instancePath)
        {
            ProblemDetails.Type = typeof(NotFoundException).Name;
            ProblemDetails.Title = "The object you're looking for doesn't exist";
            ProblemDetails.Status = (int)HttpStatusCode.NotFound;
            ProblemDetails.Detail = message;
        }
    }
}
