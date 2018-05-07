using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TrafficWeb.Model;

namespace TrafficWeb.Data
{
    public class CarDbContext : DbContext
    { 
        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }        
    }
}
