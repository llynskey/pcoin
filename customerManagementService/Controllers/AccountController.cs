using Microsoft.AspNetCore.Mvc;
using customerManagementService.Models;
using customerManagementService.Services;
using System.Threading.Tasks;
using Flurl.Http;

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
        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        {
           _customerService.Create(customer);
            try
            {
                var responseString = await "http://localhost:4321"
                   .PostJsonAsync(new { ownerId = customer._id })
                   .ReceiveString();
            }
            catch (FlurlHttpException exception)
            {
                return StatusCode(500,exception);
            }
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
