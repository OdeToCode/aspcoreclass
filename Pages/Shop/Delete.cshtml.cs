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
    public class DeleteModel : PageModel
    {
        private readonly aspcoreclass.Data.CoffeeDbContext _context;

        public DeleteModel(aspcoreclass.Data.CoffeeDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Coffee = await _context.Coffees.FindAsync(id);

            if (Coffee != null)
            {
                _context.Coffees.Remove(Coffee);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
