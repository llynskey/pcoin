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
        private static readonly HttpClient _client = new HttpClient();


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
                var responseString = await "http://jwt.pcoin.life"
                .PostUrlEncodedAsync(new { Username = vendor.Username })
                .ReceiveString();
                System.Console.WriteLine(responseString);
            };
            return response;
        }

        [HttpPost("customer")]
        public ActionResult<Customer> LoginCustomer(Customer customer)
        {
            var Customer = _customerService.Get(customer.Username);
            var response = Customer != null && customer.Pass == Customer.Pass ? (ActionResult) Ok() : (ActionResult) Unauthorized();
            return response;
        }
    }
}
