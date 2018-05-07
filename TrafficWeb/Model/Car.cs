using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrafficWeb.Model
{
    public class Car
    {
        public int Id { get; set; }

        [Range(1920, 2050)]
        public int Year { get; set; }

        [Required]
        [StringLength(255)]
        public string Manufacturer { get; set; }
    }
}
