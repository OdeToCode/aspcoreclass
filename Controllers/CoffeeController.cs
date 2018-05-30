using aspcoreclass.Models;
using aspcoreclass.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspcoreclass.Controllers
{
    [Route("/api/[controller]")]
    public class CoffeeController : Controller
    {       
        private readonly ICoffeeDb db;

        public CoffeeController(ICoffeeDb db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var model = db.GetAll();
            var result = new ObjectResult(model);
            return result;
        }

        [HttpGet("{coffeeId}")]
        public IActionResult Get(int coffeeId)
        {
            var model = db.Get(coffeeId);
            if(model == null)
            {                
                return NotFound();
            }
            var result = new ObjectResult(model);
            return result;
        }

        [HttpDelete("{coffeeId}")]
        public IActionResult Delete(int coffeeId)
        {
            db.Delete(coffeeId);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Coffee updatedCoffee)
        {
            if (ModelState.IsValid)
            {
                var model = db.Update(updatedCoffee);
                if(model != null)
                {
                    var result = new ObjectResult(model);
                    return result;
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public IActionResult Create(
                        [FromBody]
                        Coffee newCoffee)
        {
            if (ModelState.IsValid)
            {
                var model = db.Add(newCoffee);

                var result = CreatedAtRoute(
                                    new { coffeeId = newCoffee.Id },
                                    model);
                return result;
            }
            return BadRequest(ModelState);
        }
        
    }
}
