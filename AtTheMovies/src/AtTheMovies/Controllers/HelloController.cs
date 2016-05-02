using AtTheMovies.Middleware;
using Microsoft.AspNet.Mvc;

namespace AtTheMovies.Controllers
{
    [Route("class/[controller]/[action]")]
    public class HelloController : Controller
    {
        private readonly IGreetingService _greeter;

        public HelloController(IGreetingService greeter)
        {
            _greeter = greeter;
        }

        public IActionResult Index()
        {
            return Content("Controller!");
        }   
    }
}