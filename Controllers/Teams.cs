using aspcoreclass.Models;
using aspcoreclass.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspcoreclass.Controllers
{
    [Route("api/[controller]")]
    public class TeamsController : Controller
    {
        private readonly ITeamData teamData;

        public TeamsController(ITeamData teamData)
        {
            this.teamData = teamData;
        }

        [HttpGet]
        public IActionResult Get()
        {

            var model = teamData.GetAll();
            var result = new ObjectResult(model);
            return result;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var model = teamData.Get(id);
            if (model == null)
            {
                return NotFound();
            }
            return new ObjectResult(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var team = teamData.Delete(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] Team updatedTeam)
        {
            if (ModelState.IsValid)
            {
                var team = teamData.Update(updatedTeam);
                return new ObjectResult(updatedTeam);
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Team newTeam)
        {
            if (ModelState.IsValid)
            {
                var team = teamData.Add(newTeam);
                return CreatedAtRoute(new { team.Id }, team);
            }
            return BadRequest(ModelState);
        }
    }
}
