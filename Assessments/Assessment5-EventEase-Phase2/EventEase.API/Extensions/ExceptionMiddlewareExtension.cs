using EventEase.API.Middleware;
using System.Runtime.CompilerServices;

namespace EventEase.API.Extensions
{
    public static class ExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }
}
