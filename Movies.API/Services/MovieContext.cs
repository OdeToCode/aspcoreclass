using Microsoft.EntityFrameworkCore;
using Movies.API.Models;

namespace Movies.API.Services
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
