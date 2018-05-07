using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrafficWeb.Data;
using TrafficWeb.Model;

namespace TrafficWeb.Controllers
{
    [Route("[controller]")]
    public class CarController : Controller
    {
        private readonly ICarDb db;

        public CarController(ICarDb db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = db.GetAll();
            var result = new ObjectResult(model);
            return result;
        }
       
        [HttpPost]
        public IActionResult Create([FromBody]Car model)
        {
            if (ModelState.IsValid)
            {
                db.Add(model);
                db.SaveChanges();
                return CreatedAtAction("Detail", new { id = model.Id }, model);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute]int id, [FromBody]Car model)
        {
            if (ModelState.IsValid)
            {
                var updatedCar = db.Update(id, model);
                if(updatedCar == null)
                {
                    return NotFound();
                }
                db.SaveChanges();
                return new ObjectResult(updatedCar);
            }
            return BadRequest(ModelState);
        }


        [HttpGet("{id}")]
        public IActionResult Detail(int id)
        {        
            var model = db.Get(id);
            if(model == null)
            {
                return NotFound();
            }
            return new ObjectResult(model);
        }
    }
}
