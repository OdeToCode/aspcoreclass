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
    public class IndexModel : PageModel
    {
        private readonly aspcoreclass.Data.CoffeeDbContext _context;

        public IndexModel(aspcoreclass.Data.CoffeeDbContext context)
        {
            _context = context;
        }

        public IList<Coffee> Coffee { get;set; }

        public async Task OnGetAsync()
        {
            Coffee = await _context.Coffees.ToListAsync();
        }
    }
}
