using aspcoreclass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspcoreclass.Services
{
    public interface ITeamData
    {
        IEnumerable<Team> GetAll();
        Team Get(int id);
    }

    public class TeamData : ITeamData
    {
        List<Team> teams = new List<Team>()
        {
            new Team { Id = 1, Name = "Sweden", Founded = 1980 },
            new Team { Id = 2 , Name = "Norway", Founded = 1970 },
            new Team { Id = 3, Name = "Brazil", Founded = 1960 }
        };

        public Team Get(int id)
        {
            return teams.FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Team> GetAll()
        {
            return teams.OrderBy(t => t.Founded);
        }
    }
}
