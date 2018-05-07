using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrafficWeb.Middleware;

namespace Microsoft.AspNetCore.Builder
{
    public static class SayHelloMiddlewareExtensions
    {
        public static IApplicationBuilder UseHelloWorld(
            this IApplicationBuilder app, SayHelloOptions options)
        {
            if(options == null)
            {
                options = new SayHelloOptions { Path = "/hello" };
            }

            app.UseMiddleware<SayHelloMiddleware>(options);
            return app;
        }
    }
}
