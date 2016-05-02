using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AtTheMovies.Middleware;
using AtTheMovies.Services;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AtTheMovies
{
    public class Startup
    {
        public Startup()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .AddEnvironmentVariables()
                .Build();

        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IGreetingService>(sp => new FancyGreeter());
            services.AddScoped<IMovieData>(sp => new InMemoryMovieData());

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseRuntimeInfoPage("/info");

            app.Use(next => ctx =>
            {
                if (ctx.Request.Path.StartsWithSegments("/error"))
                {
                    throw new Exception("Opps!");
                }
                return next(ctx);
            });


            app.UseGreeter(new GreetingOptions()
            {
                Path = "/foo",
                Message = Configuration["message"]
            });

            app.UseStaticFiles();

            app.UseMvc(rb =>
            {
                rb.MapRoute("FirstRoute", "mvc",
                    new {controller = "Hello", action = "Index"});

                // /home/start
                rb.MapRoute("Default", "{controller=Hello}/{action=Index}");

            });
        }

        //private RequestDelegate GreetingMiddleware(RequestDelegate next)
        //{
        //    return ctx =>
        //    {
        //        if (ctx.Request.Path.StartsWithSegments("/greeting"))
        //        {
        //            return ctx.Response.WriteAsync("Hello, from GreetingMiddlware");
        //        }
        //        else
        //        {
        //            return next(ctx);
        //        }
        //    };
        //}


        // Entry point for the application.
        public static void Main(string[] args) 
        {
            WebApplication.Run<Startup>(args);
        }
    }
}
