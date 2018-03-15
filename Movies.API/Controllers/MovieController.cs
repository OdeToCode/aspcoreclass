using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Movies.API.Models;
using Movies.API.Services;

namespace Movies.API.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private readonly IMovieDb db;

       /*  api/movies
        *  api/movies/3
        *  api/movies/3/awards
        *  
        *  api/movies/3/actors/2
        *  api/actors/2
        */

        public MoviesController(IMovieDb db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var model = db.GetAll();
            return Ok(model);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Movie newMovie)
        {
            if (ModelState.IsValid)
            {
                var movie = db.Create(newMovie);
                return CreatedAtAction(nameof(Get), new { movie.Id }, movie);

            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Movie updatedMovie)
        {
            if (ModelState.IsValid)
            {
                var movie = db.Update(updatedMovie);
                return Ok(movie);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{movieId}")]
        public IActionResult Delete(int movieID)
        {
            var movie = db.Delete(movieID);
            if(movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }
    }
}