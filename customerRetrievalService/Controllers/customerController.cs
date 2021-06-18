using System;
using Microsoft.AspNetCore.Mvc;
using customerRetrievalService.Models;
using customerRetrievalService.Services;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;

namespace customerRetrievalService.Controllers
{
    [Route("/")]
    [ApiController]
    public class customerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public customerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult getcustomer(string id){
            Customer Customer = _customerService.Get(id);
            Customer.Pass = null;
            return Ok(Customer);
        }

    }
}
