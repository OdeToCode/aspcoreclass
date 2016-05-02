using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtTheMovies.Middleware;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;


namespace  Microsoft.AspNet.Builder
{
    public static class GreetingMiddlewareExt
    {
        public static IApplicationBuilder UseGreeter(
            this IApplicationBuilder app, GreetingOptions options)
        {
            app.UseMiddleware<GreetingMiddleware>(options);
            return app;
        }
    }
}

namespace AtTheMovies.Middleware
{
    public interface IGreetingService
    {
        string GetGreeting();
    }

    public class FancyGreeter : IGreetingService
    {
        static private int _count = 0;
        public FancyGreeter()
        {
            _count += 1;
        }

        public string GetGreeting()
        {
            
            return $"This is greeting from service number {_count}";
        }
    }


    public class GreetingOptions
    {
        public GreetingOptions()
        {
            Message = "Hello from a configuratlbe greeter";
            Path = "/greeting";
        }

        public string Message { get; set; }
        public string Path { get; set; }
    }


    public class GreetingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly GreetingOptions _options;

        public GreetingMiddleware(RequestDelegate next, 
                                 GreetingOptions options)
        {
            _next = next;
            _options = options;
        }

        public Task Invoke(HttpContext ctx, IGreetingService service)
        {
            if (ctx.Request.Path.StartsWithSegments(_options.Path))
            {
                return ctx.Response.WriteAsync(service.GetGreeting());
            }
            else
            {
                return _next(ctx);
            }
        }
    }
}
