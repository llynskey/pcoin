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

        [HttpPut("/edit")]

        public ActionResult<Voucher> Edit(Voucher voucher)
        {
            _voucherService.Edit(voucher._id,voucher);
            return Ok();
        }

        [HttpPut("/offeredBy")]

        public ActionResult<Voucher> AddVoucherToVenue(Voucher voucher)
        {
            System.Console.WriteLine(voucher);
            _voucherService.AddOfferedBy(voucher._id, voucher);
            return Ok();
        }
    }
}
