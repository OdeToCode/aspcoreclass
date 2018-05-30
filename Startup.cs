using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspcoreclass.Middleware;
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


        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, 
                            IHostingEnvironment env)
        {

            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();              
            }

            app.UseStaticFiles();

            var options = new SayHelloOptions
            {
                Path = "/sayhello",
                Greeting = configuration["Greeting"]
            };
            app.UseGreeting(options);
           
         }
    }
}
