using BookStore.API.REST.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace BookStore.API.REST.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionHandlerMiddleware>();
            return builder;
        }
    }
}
