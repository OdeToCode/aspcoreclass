using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtTheMovies.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        [Required, MaxLength(80)]
        public string Title { get; set; }
        public int Length { get; set; }
    }
}
