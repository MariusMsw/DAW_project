using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Models
{
    public class AuthenticationResponse
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public string Token { get; set; }
    }
}
