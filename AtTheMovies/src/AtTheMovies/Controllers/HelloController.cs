using Microsoft.AspNet.Mvc;

namespace AtTheMovies.Controllers
{
    public class HelloController : Controller
    {
        public IActionResult Index()
        {
            return Content("Hello, this is content!");
        }   
    }
}