using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrafficWeb.Data;
using TrafficWeb.Middleware;
using TrafficWeb.Services;

namespace TrafficWeb
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

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            }).AddOpenIdConnect(options =>
            {
                configuration.Bind("AzureAd", options);
            })
            .AddCookie();

            services.AddDbContext<CarDbContext>(options =>
              options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));



            services.AddScoped<ICarDb, SqlCarDb>();
            services.AddSingleton<IGreeter, Greeter>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                              IHostingEnvironment env)
        {
          
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Exception");
            }

                         
            app.UseHelloWorld(new SayHelloOptions { Path = "/ndc" });        
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
