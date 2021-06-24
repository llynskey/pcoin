using Microsoft.AspNetCore.Mvc;
using voucherManagementService.Models;
using voucherManagementService.Services;

namespace voucherManagementService.Controllers
{
    [Route("/")]
    [ApiController]
    public class voucherController : ControllerBase
    {
        private readonly voucherService _voucherService;
    
        public voucherController(voucherService voucherService)
        {
            _voucherService = voucherService;
        } 

        [HttpPost]
        public ActionResult<Voucher> CreateVoucher(Voucher voucher)
        {
            _voucherService.Create(voucher);
            return Ok();
        }

        /*[HttpPost("voucher")]
        public ActionResult AddVoucher(voucher voucher, Voucher voucher)
        {
            System.Console.WriteLine("venID"+voucher._id);
            System.Console.WriteLine("VCHR"+voucher.ToString());
           // _voucherService.AddVoucher(voucherId, voucher);
            return Ok();
        }*/
    }
}
