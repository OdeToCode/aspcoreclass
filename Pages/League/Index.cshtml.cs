using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using aspcoreclass.Models;
using aspcoreclass.Services;

namespace aspcoreclass.Pages
{
    public class IndexModel : PageModel
    {
        private readonly aspcoreclass.Services.TeamDbContext _context;

        public IndexModel(aspcoreclass.Services.TeamDbContext context)
        {
            _context = context;
        }

        public IList<Team> Team { get;set; }

        public async Task OnGetAsync()
        {
            Team = await _context.Teams.ToListAsync();
        }
    }
}
