using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace LoginService.Models
{
    public class Vendor : User
    {
        public int[] venues { get; set; }
    }
}