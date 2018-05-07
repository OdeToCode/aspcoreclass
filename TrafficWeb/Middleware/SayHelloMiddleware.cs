using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using TrafficWeb.Services;

namespace TrafficWeb.Middleware
{
    public class SayHelloMiddleware
    {
        private readonly RequestDelegate next;
        private readonly SayHelloOptions options;

        public SayHelloMiddleware(
            RequestDelegate next, 
            SayHelloOptions options)
        {
            this.next = next;
            this.options = options;
        }

        public async Task Invoke(HttpContext ctx, 
                                IHostingEnvironment env, IGreeter greeter)
        {
            if (ctx.Request.Path.StartsWithSegments(options.Path))
            {
                ctx.Response.StatusCode = 200;
                ctx.Response.Headers.Add("Content-Type", "text/plain");
                await ctx.Response.WriteAsync($"{greeter.GetMessageOfTheDay()} from {env.EnvironmentName}");
            }
            else
            {
                await next(ctx);
            }
        }

    }
}
