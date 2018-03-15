using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApp.Services
{

    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddGreeter(this IServiceCollection services)
        {
            services.AddSingleton<IGreeter, Greeter>();
            return services;
        }
    }


    public interface IGreeter
    {
        string GetMessageOfTheDay();
    }


    public class Greeter : IGreeter
    {
        private readonly IConfiguration config;

        public Greeter(IConfiguration config)
        {
            this.config = config;
        }

        public string GetMessageOfTheDay()
        {
            return config["Greeting"];
        }
    }
}
