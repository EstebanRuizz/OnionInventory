using webAPI.Middlewares;

namespace webAPI.Extensions
{
    public static class APIExtension
    {
        public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
