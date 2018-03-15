using FirstApp.Middleware;
using FirstApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Microsoft.AspNetCore.Builder
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder UseGreeter(
            this IApplicationBuilder builder,
            GreetingOptions options)
        {

            builder.UseMiddleware<GreetingMiddleware>(options);
            return builder;
        }
    }
}


namespace FirstApp.Middleware
{


    public class GreetingOptions
    {
        public string Path { get; set; } = "/greeting";
    }


    public class GreetingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly GreetingOptions options;
        private readonly ILogger logger;

        public GreetingMiddleware(RequestDelegate next, GreetingOptions options, 
                                  ILoggerFactory logger)
        {
            this.next = next;
            this.options = options;
            this.logger = logger.CreateLogger<GreetingMiddleware>();
        }
    
        public async Task Invoke(HttpContext context, IGreeter greeter)
        {
            if (context.Request.Path.StartsWithSegments(options.Path))
            {
                logger.LogInformation("Greeting middleware handling request");

                var message = greeter.GetMessageOfTheDay();
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync($"Message is: {message}");
            }
            else
            {
                logger.LogInformation($"Greeting allowing {context.Request.Path} to pass through");
                await next(context);
                // ...
                logger.LogInformation($"Previous middlware complete with {context.Response.StatusCode}");

            }
        }

    }
}
