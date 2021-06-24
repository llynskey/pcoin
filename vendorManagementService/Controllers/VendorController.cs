using Microsoft.AspNetCore.Mvc;
using vendorManagementService.Models;
using vendorManagementService.Services;

namespace vendorManagementService.Controllers
{
    [Route("/")]
    [ApiController]
    public class vendorController : ControllerBase
    {
        private readonly VendorService _VendorService;
        
        public vendorController(VendorService VendorService)
        {
            _VendorService = VendorService;
        }

        [HttpPost]
        public ActionResult<User> CreateVendor(Vendor vendor)
        {
            _VendorService.Create(vendor);
            return Ok();
        }

  

    }
}
