using Microsoft.AspNetCore.Mvc;
using AccountService.Models;
using AccountService.Services;

namespace AccountService.Controllers
{
    [Route("/")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly VendorService _vendorService;
        private readonly CustomerService _customerService;
        
        public AccountController(VendorService vendorService, CustomerService customerService)
        {
            _vendorService = vendorService;
            _customerService = customerService;
        }

        [HttpPost("vendor")]
        public ActionResult<User> CreateVendor(Vendor vendor)
        {
            _vendorService.Create(vendor);
            return Ok();
        }

        [HttpPost("customer")]
        public ActionResult<Customer> CreateCustomer(Customer customer)
        {
           _customerService.Create(customer);
            return Ok();
        }

    }
}
