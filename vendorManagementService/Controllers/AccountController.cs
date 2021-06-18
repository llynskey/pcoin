using Microsoft.AspNetCore.Mvc;
using vendorManagementService.Models;
using vendorManagementService.Services;

namespace vendorManagementService.Controllers
{
    [Route("/")]
    [ApiController]
    public class vendorController : ControllerBase
    {
        private readonly VendorService _vendorService;
        
        public vendorController(VendorService vendorService)
        {
            _vendorService = vendorService;
        }

        [HttpPost]
        public ActionResult<User> CreateVendor(Vendor vendor)
        {
            _vendorService.Create(vendor);
            return Ok();
        }

  

    }
}
