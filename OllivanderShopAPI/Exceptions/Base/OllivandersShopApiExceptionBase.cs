using Microsoft.AspNetCore.Mvc;

namespace OllivandersShopAPI.Exceptions.Base
{
    public abstract class OllivandersShopApiExceptionBase : Exception
    {
        public readonly ProblemDetails ProblemDetails = new ProblemDetails();

        protected OllivandersShopApiExceptionBase(string message, string instancePath) : base(message)
        {
            ProblemDetails.Instance = instancePath;
        }
    }
}
