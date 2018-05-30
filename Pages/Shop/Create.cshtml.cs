using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using aspcoreclass.Data;
using aspcoreclass.Models;

namespace aspcoreclass
{
    public class CreateModel : PageModel
    {
        private readonly aspcoreclass.Data.CoffeeDbContext _context;

        public CreateModel(aspcoreclass.Data.CoffeeDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Coffee Coffee { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Coffees.Add(Coffee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}