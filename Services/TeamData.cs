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
        Team Add(Team newTeam);
        Team Update(Team updatedTeam);
        Team Delete(int id);
    }

    public class TeamData : ITeamData
    {
        List<Team> teams = new List<Team>()
        {
            new Team { Id = 1, Name = "Sweden", Founded = 1980 },
            new Team { Id = 2 , Name = "Norway", Founded = 1970 },
            new Team { Id = 3, Name = "Brazil", Founded = 1960 }
        };

        public Team Add(Team newTeam)
        {
            newTeam.Id = teams.Max(t => t.Id) + 1;
            teams.Add(newTeam);
            return newTeam;
        }

        public Team Delete(int id)
        {
            var team = teams.FirstOrDefault(t => t.Id == id);
            if (team != null)
            {
                teams.Remove(team);
            }
            return team;
        }

        public Team Get(int id)
        {
            return teams.FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Team> GetAll()
        {
            return teams.OrderBy(t => t.Founded);
        }

        public Team Update(Team updatedTeam)
        {
            var team = teams.FirstOrDefault(t => t.Id == updatedTeam.Id);
            if(team != null)
            {
                team.Name = updatedTeam.Name;
                team.Founded = updatedTeam.Founded;
            }
            return team;
        }
    }
}
