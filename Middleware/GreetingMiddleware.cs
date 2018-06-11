using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspcoreclass.Middleware
{
    public class GreetingOptions
    {
        public string Path { get; set; }
        public string Message { get; set; }
    }

    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder UseGreeting(
            this IApplicationBuilder app, GreetingOptions options)
        {
            app.UseMiddleware<GreetingMiddleware>(options);
            return app;
        }
    }

    public class GreetingMiddleware 
    {
        private readonly RequestDelegate next;
        private readonly GreetingOptions options;

        public GreetingMiddleware(RequestDelegate next, GreetingOptions options)
        {
            this.next = next;
            this.options = options;
        }

        public async Task Invoke(HttpContext context)
        {           
            if (context.Request.Path.StartsWithSegments(options.Path))
            {
                context.Response.Headers.Add("Content-Type", "text/plain");
                await context.Response.WriteAsync(options.Message);
            }
            else
            {
                await next(context);
            }
        }
    }
}
