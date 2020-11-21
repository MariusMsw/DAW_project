using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Entities
{
    public class User
    {

        [Key]
        public int UserId { get; set; }

        public string Mail { get; set; }

        public string Password { get; set; }
    }
}
