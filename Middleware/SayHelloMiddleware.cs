using aspcoreclass.Services;
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
    }


    public class SayHelloMiddleware
    {
        private readonly RequestDelegate next;
        private readonly SayHelloOptions options;

        public SayHelloMiddleware(RequestDelegate next, 
                                SayHelloOptions options,
                                IGreeter greeter)
        {
            this.next = next;
            this.options = options;
            Greeter = greeter;
        }

        public IGreeter Greeter { get; }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments(options.Path))
            {
                context.Response.StatusCode = 200;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync(Greeter.GetMessage());
            }
            else
            {
                await next(context);
            }
        }
    }
}
