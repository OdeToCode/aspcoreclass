using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspcoreclass.Data;
using aspcoreclass.Middleware;
using aspcoreclass.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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


        public void ConfigureServices(
            IServiceCollection services)
        {
            services.AddDbContext<CoffeeDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("CoffeeDb"));
            });
            services.AddMvc();
            services.AddScoped<ICoffeeDb, SqlCoffeeDb>();
            services.AddSingleton<IGreeter, ConfigurableGreeter>();
        }

        public void Configure(
            IApplicationBuilder app, 
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
            };
            app.UseGreeting(options);

            app.UseMvc();
           
         }
    }
}
