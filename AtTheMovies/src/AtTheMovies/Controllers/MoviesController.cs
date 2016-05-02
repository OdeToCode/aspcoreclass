using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtTheMovies.Entities;
using AtTheMovies.Services;
using Microsoft.AspNet.Mvc;

namespace AtTheMovies.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private readonly IMovieData _movieData;

        public MoviesController(IMovieData movieData)
        {
            _movieData = movieData;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var model = _movieData.GetAll();
            var result=  new ObjectResult(model);
            result.StatusCode = 200;
            return result;
        }

        [Route("{id:int}")]
        [HttpGet]
        public IActionResult Get([FromRoute] int id)
        {
            var model = _movieData.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return new ObjectResult(model);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieData.Create(movie);
                return CreatedAtAction("Get", new { id = movie.Id});
            }
            return HttpBadRequest(ModelState);
        }
    }
}
