using aspcoreclass.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspcoreclass.Data
{
    public class CoffeeDbContext : DbContext
    {
        public CoffeeDbContext(DbContextOptions<CoffeeDbContext> options)
             : base(options)
        {

        }

        public DbSet<Coffee> Coffees { get; set; }
    }
}
