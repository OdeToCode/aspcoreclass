using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrafficWeb.Data;
using TrafficWeb.Model;

namespace TrafficWeb.Pages
{
    [Authorize]
    public class NewCarModel : PageModel
    {
        private readonly ICarDb db;

        [BindProperty]
        public Car NewCar { get; set; }

        public NewCarModel(ICarDb db)
        {
            this.db = db;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                db.Add(NewCar);
                db.SaveChanges();
                return RedirectToPage("CarList");
            }
            return Page();
        }
    }
}