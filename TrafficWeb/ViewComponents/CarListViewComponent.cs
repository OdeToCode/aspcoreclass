using Microsoft.AspNetCore.Mvc;
using TrafficWeb.Data;

namespace TrafficWeb.ViewComponents
{
    public class CarListViewComponent : ViewComponent
    {
        private readonly ICarDb db;

        public CarListViewComponent(ICarDb db)
        {
            this.db = db;
        }

        public IViewComponentResult Invoke()
        {
            var model = db.GetAll();
            return View(model);
        }
    }
}
