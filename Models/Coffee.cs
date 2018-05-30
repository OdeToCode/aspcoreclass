using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aspcoreclass.Models
{
    public enum CoffeeType
    {
        Espresso,
        Latte,
        Mocha
    }

    public class Coffee
    {
        public int Id { get; set; }


        [Required]
        [StringLength(80)]        
        public string Name { get; set; }


        [Range(0, 2)]
        public CoffeeType Type { get; set; }
    }
}
