using Microsoft.AspNetCore.Mvc;
using customerManagementService.Models;
using customerManagementService.Services;

namespace customerManagementService.Controllers
{
    [Route("/")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly CustomerService _customerService;
        
        public AccountController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public ActionResult<Customer> CreateCustomer(Customer customer)
        {
           _customerService.Create(customer);
            return Ok();
        }

        [HttpPut]
        public ActionResult<Customer> EditCustomer(Customer customer)
        {
            _customerService.Edit(customer);
            return Ok();
        }
    }
}
