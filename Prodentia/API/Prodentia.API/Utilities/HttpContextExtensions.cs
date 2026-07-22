namespace Prodentia.API.Utilities
{
    public static class HttpContextExtensions
    {
        public static void AddPaginationHeader(this HttpContext httpContext, int totalAmountOfRecords)
        {
            httpContext.Response.Headers.Append("X-Total-Count", totalAmountOfRecords.ToString());
        }
    }
}
