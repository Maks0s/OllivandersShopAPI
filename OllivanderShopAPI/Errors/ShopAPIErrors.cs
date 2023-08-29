using ErrorOr;
using System.Net;

namespace OllivandersShopAPI.Errors
{
    public static class ShopAPIErrors
    {
        public static Error NotFound(string message)
        {
            return Error.Custom(StatusCodes.Status404NotFound, "The object you're looking for doesn't exist", message);
        }

        public static Error ServerSide(string message)
        {
            return Error.Custom(StatusCodes.Status500InternalServerError, "Unexpected problems on the server side. Try again a little later", message);
        }

        public static Error IncorrectObjectSent(string message)
        {
            return Error.Custom(StatusCodes.Status400BadRequest, "The object you're sending is NULL or not correct", message);
        }
    }
}
