using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace voucherManagementService.Models
{
    public class Voucher
    {        
        public String Name { get; set; }
        public int Price { get; set; }
        public List<String> OfferedBy {get; set;}
    }
}
