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

    public class ConfigGreeter : IGreeter
    {
        private readonly IConfiguration config;

        public ConfigGreeter(IConfiguration config)
        {
            this.config = config;
        }

        public string GetMessage()
        {
            return config["Message"];
        }
    }
}
