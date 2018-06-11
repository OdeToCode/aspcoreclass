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
    public class TeamsController
    {
        private readonly ITeamData teamData;

        public TeamsController(ITeamData teamData)
        {
            this.teamData = teamData;
        }

        [HttpGet]
        public IEnumerable<Team> Get()
        {
            return teamData.GetAll();
        }

        [HttpGet("{id}")]
        public Team Get(int id)
        {
            return teamData.Get(id);
        }
    }
}
