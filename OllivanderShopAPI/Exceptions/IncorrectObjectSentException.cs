﻿using OllivandersShopAPI.Exceptions.Base;
using System.Net;

namespace OllivandersShopAPI.Exceptions
{
    public class IncorrectObjectSentException : OllivandersShopApiExceptionBase
    {
        public IncorrectObjectSentException(string message, string instancePath) : base(message, instancePath)
        {
            ProblemDetails.Type = @"https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
            ProblemDetails.Title = "The object you're sending is NULL or not correct";
            ProblemDetails.Status = (int)HttpStatusCode.BadRequest;
            ProblemDetails.Detail = message;
        }
    }
}
