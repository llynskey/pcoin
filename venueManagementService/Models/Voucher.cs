using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace venueManagementService.Models
{
    public class Voucher
    {
     /*   public Voucher(int id ,string name, int price, bool available)
        {
            _voucherId = id;
            Name = name;
            Price = price;
            //Available = available;
        }*/

       public int _voucherId { get; set; }
       public  string Name { get; set; }
       public int Price { get; set; }
        //bool Available { get; set; }
    }
}
