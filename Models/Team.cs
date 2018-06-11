﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aspcoreclass.Models
{
    public class Team 
    {
        public int Id { get; set; }

        [Required]       
        [StringLength(80)]       
        public string Name { get; set; }

        [Range(1890, 2100)]
        public int Founded { get; set; }
    }
}
