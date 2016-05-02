using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtTheMovies.Entities;
using AtTheMovies.Services;
using Microsoft.AspNet.Mvc;

namespace AtTheMovies.Controllers
{
    [Route("/"), Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IMovieData _movieData;

        public HomeController(IMovieData movieData)
        {
            _movieData = movieData;
        }

        public IActionResult Index()
        {
            var model = _movieData.GetAll();

            return View(model);
        }

        [HttpPost]
        [Route("{id:int}")]
        public IActionResult Edit(Movie updatedMovie)
        {
            if (ModelState.IsValid)
            {
                _movieData.Save(updatedMovie);
                return RedirectToAction("Details", new { id = updatedMovie.Id});
            }
            return View(updatedMovie);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Edit(int id)
        {
            var model = _movieData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [Route("{id:int}")]
        public IActionResult Details(int id)
        {
            var model = _movieData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

    }
}
