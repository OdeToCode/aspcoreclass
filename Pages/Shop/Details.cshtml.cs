using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using aspcoreclass.Data;
using aspcoreclass.Models;

namespace aspcoreclass
{
    public class DetailsModel : PageModel
    {
        private readonly aspcoreclass.Data.CoffeeDbContext _context;

        public DetailsModel(aspcoreclass.Data.CoffeeDbContext context)
        {
            _context = context;
        }

        public Coffee Coffee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Coffee = await _context.Coffees.FirstOrDefaultAsync(m => m.Id == id);

            if (Coffee == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
