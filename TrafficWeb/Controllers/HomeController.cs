using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrafficWeb.Controllers
{
    [Route("")]
    [Route("[controller]/[action]")]
    public class HomeController
    {

        [Route("/foo/bar")]
        public string SayHello()
        {
            return "foo bar";
        }

        public string Index()
        {
            return "Hello from a controller - now using VSTS";
        }

        [Route("{name}")]
        public string Detail(string name)
        {
            return $"Detail for {name}";
        }
    }
}
