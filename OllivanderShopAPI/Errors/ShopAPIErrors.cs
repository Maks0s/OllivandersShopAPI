using ErrorOr;

namespace OllivandersShopAPI.Errors
{
    public static class ShopAPIErrors
    {
        public static Error NotFound(string message)
        {
            return Error.Custom(404, "The object you're looking for doesn't exist", message);
        }

        public static Error ServerSide(string message)
        {
            return Error.Custom(500, "Unexpected problems on the server side. Try again a little later", message);
        }

        public static Error IncorrectObjectSent(string message)
        {
            return Error.Custom(400, "The object you're sending is NULL or not correct", message);
        }
    }
}
