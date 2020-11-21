using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Entities
{
    public class Laptop
    {
        [Key]
        public int LaptopId { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string CPU { get; set; }

        public int RAM { get; set; }

        public string OS { get; set; }

        public Employee Employee { get; set; }
    }
}
