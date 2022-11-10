using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyLibrary;
using DL;

namespace logInHW
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RatingMiddleware
    {
        private readonly RequestDelegate _next;

        public RatingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, api212796Context DBcontext)
        {
            Rating r = new Rating();
            r.RatingId = 0;
            r.Host = httpContext.Request.Host.Value;
            r.Method = httpContext.Request.Method;
            r.Path = httpContext.Request.Path;
            r.Referer = httpContext.Request.Headers["Referer"];
            r.UserAgent = httpContext.Request.Headers["User-Agent"];
            r.RecordDate = DateTime.Now;
            await DBcontext.Ratings.AddAsync(r);
            await DBcontext.SaveChangesAsync();
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseRatingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RatingMiddleware>();
        }
    }
}
