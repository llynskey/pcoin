using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthService.Models
{
    public class Customer : User
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime DOB { get; set; }
    }
}
