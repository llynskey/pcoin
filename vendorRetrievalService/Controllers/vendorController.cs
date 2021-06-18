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
        public ActionResult<Vendor> getVendor(Vendor vendor){
            Vendor Vendor = _vendorService.Get(vendor._id);
            Vendor.Pass = null;
            return Ok(Vendor);
        }

    }
}
