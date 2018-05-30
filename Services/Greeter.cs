using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspcoreclass.Services
{
    public interface IGreeter
    {
        string GetMessage();
    }

    public class ConfigurableGreeter : IGreeter
    {
        private readonly IConfiguration configuration;

        public ConfigurableGreeter(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GetMessage()
        {
            return configuration["Greeting"];
        }
    }
}
