using FirstApp.Models;
using FirstApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApp.Controllers
{

    public class MovieSearchModel
    {
        public int Year { get; set; }
        public string SearchTerm { get; set; }
        [Range(minimum:1, maximum:300)]
        public int Page { get; set; } = 1;
    }


    [Route("admin/[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IGreeter greeter;

        public HomeController(IGreeter greeter)
        {
            this.greeter = greeter;
        }

        // /movies/search/year/searchterm
        // /movies/search/1999/star

        
        [HttpGet("/movies/search/{year}/{searchTerm}")]
        public IActionResult Foo(MovieSearchModel inputModel)
        {
            if (ModelState.IsValid)
            {            
                return new OkObjectResult(inputModel);
            }

            return BadRequest(ModelState);          
        }

        public IActionResult Get()
        {
            var model = new List<Movie>()
            {
                new Movie { Id = 1, Title = "Star Wars", ReleaseYear=1977 },
                new Movie { Id = 2, Title = "STar Trek", ReleaseYear=1984 },
                new Movie { Id = 3, Title = "The Matrix", ReleaseYear=1992 }
            };

            var result = new ObjectResult(model);
            return result;

        }
    }
}
