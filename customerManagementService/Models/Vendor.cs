﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace customerManagementService.Models
{
    public class Vendor : User
    {
        public String Type = "Vendor";
        public int[] venues { get; set; }
    }
}