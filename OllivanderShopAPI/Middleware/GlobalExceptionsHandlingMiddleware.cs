

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OllivandersShopAPI.Exceptions;
using OllivandersShopAPI.Exceptions.Base;
using System.Net;

namespace OllivandersShopAPI.Middleware
{
    public class GlobalExceptionsHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public GlobalExceptionsHandlingMiddleware(RequestDelegate next, ILogger<GlobalExceptionsHandlingMiddleware> logger)
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
                await HandleException(context, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            var problemDetails = new ProblemDetails();

            switch (ex)
            {
                case OllivandersShopApiExceptionBase exception:
                    problemDetails = exception.ProblemDetails;
                    _logger.LogError("{@problemDetails}", problemDetails);
                    break;
                case Exception unhandled:
                    problemDetails.Type = nameof(unhandled);
                    problemDetails.Title = "Unexpected problems on the server side. Try again a little later";
                    problemDetails.Status = (int)HttpStatusCode.InternalServerError;
                    problemDetails.Detail = unhandled.Message;
                    problemDetails.Instance = unhandled.Source;
                    _logger.LogError("{@problemDetails}", problemDetails);
                    break;
            }

            return context.Response.WriteAsJsonAsync(problemDetails);
        }
    }

}
