using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OllivandersShopAPI.Errors;
using System;
using System.Net;

namespace OllivandersShopAPI.Controllers
{
    [Route("/error")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        private readonly ILogger<ErrorController> _logger;
        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        public ActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            var problemDetails = new ProblemDetails()
            {
                Title = "Unexpected problems on the server side. Try again a little later",
                Status = (int)HttpStatusCode.InternalServerError,
                Detail = exception?.Message,
                Instance = exception?.Source
            };

            _logger.LogError(exception, "{@problemDetails}", problemDetails);

            return Problem(
                title: problemDetails.Title,
                detail: problemDetails.Detail,
                instance: problemDetails.Instance,
                statusCode: problemDetails.Status
                );
        }
    }
}
