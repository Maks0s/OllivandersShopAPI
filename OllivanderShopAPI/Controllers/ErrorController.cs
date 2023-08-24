using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OllivandersShopAPI.Exceptions.Base;
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

        public async Task<ActionResult> Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            var problemDetails = new ProblemDetails();

            switch (exception)
            {
                case OllivandersShopApiExceptionBase shopException:
                    problemDetails = shopException.ProblemDetails;
                    _logger.LogError("{@problemDetails}", problemDetails);
                    break;
                case Exception unhandled:
                    problemDetails.Title = "Unexpected problems on the server side. Try again a little later";
                    problemDetails.Status = (int)HttpStatusCode.InternalServerError;
                    problemDetails.Detail = unhandled.Message;
                    problemDetails.Instance = unhandled.Source;
                    _logger.LogError(exception, "{@problemDetails}", problemDetails);
                    break;
            }

            return Problem(
                title: problemDetails.Title,
                detail: problemDetails.Detail,
                instance: problemDetails.Instance,
                statusCode: problemDetails.Status
                );
        }
    }
}
