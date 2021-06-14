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
            var response = Vendor != null && vendor.Pass == Vendor.Pass ? (ActionResult) Ok() : (ActionResult) Unauthorized();
            if(response == (ActionResult)Ok())
            {
                var responseString = await "http://auth.pcoin.life/create"
                .PostJsonAsync(new { Username = vendor.Username })
                .ReceiveString();
                System.Console.WriteLine(responseString);
            };
            return response;
        }

        [HttpPost("customer")]
        public async Task<ActionResult<Customer>> LoginCustomerAsync(Customer customer)
        {
            var Customer = _customerService.Get(customer.Username);
            var response = Customer != null && customer.Pass == Customer.Pass ? "OK": "NotOkay";
            Console.WriteLine(response);
            if (response == "OK")
            {
                System.Console.WriteLine("here");
                var responseString = await "http://auth.pcoin.life/create"
                .PostJsonAsync(new { Username = customer.Username })
                .ReceiveString();
                System.Console.WriteLine(responseString);
                return Ok(responseString);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
