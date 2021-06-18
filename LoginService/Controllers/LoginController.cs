using System;
using Microsoft.AspNetCore.Mvc;
using LoginService.Models;
using LoginService.Services;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;

namespace LoginService.Controllers
{
    [Route("/")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly VendorService _vendorService;
        private readonly CustomerService _customerService;

        public LoginController(VendorService vendorService, CustomerService customerService)
        {
            _vendorService = vendorService;
            _customerService = customerService;
        }

       

        [HttpPost("vendor")]
        public async Task<ActionResult<Vendor>> LoginVendorAsync(Vendor vendor)
        {
            var Vendor = _vendorService.Get(vendor.Username);
            var response = Vendor != null && vendor.Pass == Vendor.Pass ? "Okay" : "NotOkay";
            if (response == "OK")
            {
                var responseString = await "http://auth.pcoin.life/create"
                .PostJsonAsync(new { _id = vendor._id, Username = vendor.Username, Type = "Vendor" })
                .ReceiveString();
                return Ok(responseString);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("customer")]
        public async Task<ActionResult<Customer>> LoginCustomerAsync(Customer customer)
        {
            var Customer = _customerService.Get(customer.Username);
            var response = Customer != null && customer.Pass == Customer.Pass ? "OK": "NotOkay";
            if (response == "OK")
            {
                var responseString = await "http://auth.pcoin.life/create"
                .PostJsonAsync(new { _id = Customer._id, Username = Customer.Username, Type = "Customer" })
                .ReceiveString();
                return Ok(responseString);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
