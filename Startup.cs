using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspcoreclass.Middleware;
using aspcoreclass.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace aspcoreclass
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<ITeamData, TeamData>();
            services.AddScoped<IGreeter, ConfigGreeter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
                IApplicationBuilder app, 
                IHostingEnvironment env, IGreeter greeter)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            var options = new GreetingOptions
            {
                Path = "/SayHello",
                Message = greeter.GetMessage()
            };
            app.UseGreeting(options);
            
            app.UseStaticFiles();

            app.UseMvc();
         
            app.Run(async (context) =>
            {            
                context.Response.StatusCode = 200;
                context.Response.Headers.Add("Content-Type", "text/plain");
                await context.Response.WriteAsync("Hello World! (not supposed to see this)");
            });

            
        }
    }
}
