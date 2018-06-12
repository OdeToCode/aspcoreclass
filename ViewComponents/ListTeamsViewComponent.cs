using aspcoreclass.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace aspcoreclass
{
    public class ListTeamsViewComponent : ViewComponent
    {
        private readonly ITeamData teamData;

        public ListTeamsViewComponent(ITeamData teamData)
        {
            this.teamData = teamData;
        }

        public IViewComponentResult Invoke(string filter)
        {
            var model = teamData.GetAll().Where(t => t.Name.StartsWith(filter));
            return View(model);
        }
    }
}
