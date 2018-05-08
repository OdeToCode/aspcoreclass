using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrafficWeb.Data;
using TrafficWeb.Model;

namespace TrafficWeb.Pages
{
    [Authorize]
    public class CarListModel : PageModel
    {
        private readonly ICarDb db;

        public IEnumerable<Car> Cars { get; set; }

        public CarListModel(ICarDb db)
        {
            this.db = db;
        }

        public void OnGet()
        {
            Cars = db.GetAll();
        }
    }
}