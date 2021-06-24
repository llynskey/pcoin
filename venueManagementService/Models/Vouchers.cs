using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace venueManagementService.Models
{
    public class Vouchers
    {
        public void addVoucher(Voucher voucher)
        {
           vouchers.Add(voucher);
        }

        public void deleteVoucher(Voucher voucher)
        {
            vouchers.Remove(voucher);
        }
        public static List<Voucher> vouchers { get; set; }
    }
}
