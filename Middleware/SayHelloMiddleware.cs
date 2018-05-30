using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspcoreclass.Middleware
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder UseGreeting(
            this IApplicationBuilder app,
            SayHelloOptions options)
        {
            app.UseMiddleware<SayHelloMiddleware>(options);
            return app;
        }
    }


    public class SayHelloOptions
    {
        public string Path { get; set; }
        public string Greeting { get; set; }
    }


    public class SayHelloMiddleware
    {
        private readonly RequestDelegate next;
        private readonly SayHelloOptions options;

        public SayHelloMiddleware(RequestDelegate next, 
                                SayHelloOptions options)
        {
            this.next = next;
            this.options = options;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments(options.Path))
            {
                context.Response.StatusCode = 200;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync(options.Greeting);
            }
            else
            {
                await next(context);
            }
        }
    }
}
