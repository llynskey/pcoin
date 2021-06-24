using System;
using Microsoft.AspNetCore.Mvc;
using vendorRetrievalService.Models;
using vendorRetrievalService.Services;

namespace vendorRetrievalService.Controllers
{
    [Route("/")]
    [ApiController]
    public class vendorController : ControllerBase
    {
        private readonly VendorService _vendorService;

        public vendorController(VendorService VendorService)
        {
            _vendorService = VendorService;
        }

        [HttpGet]
        public ActionResult getVendor(string id){
            Vendor Vendor = _vendorService.Get(id);
            if (Vendor != null)
            {
                Vendor.Pass = null;
                return Ok(Vendor);
            }
            else
            {
                return NotFound("Vendor Not Found");
            }
        }

    }
}
