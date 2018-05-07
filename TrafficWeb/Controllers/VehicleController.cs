using Microsoft.AspNetCore.Mvc;
using TrafficWeb.Data;

namespace TrafficWeb
{
    [Route("[controller]/[action]")]
    public class VehicleController : Controller
    {
        private readonly ICarDb db;

        public VehicleController(ICarDb db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }
    }
}
