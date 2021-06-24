using Microsoft.AspNetCore.Mvc;
using pointManagementService.Models;
using pointManagementService.Services;

namespace pointManagementService.Controllers
{
    [Route("/")]
    [ApiController]
    public class pointController : ControllerBase
    {
        private readonly PointService _PointService;
        
        public pointController(PointService PointService)
        {
            _PointService = PointService;
        }

        [HttpPost]
        public ActionResult CreatePointAccount(PointAccount pointAccount)
        {
            System.Console.WriteLine(pointAccount.ownerId);
            if (_PointService.CreateAccount(pointAccount.ownerId) == true)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500, "Account already exists");
            }
        }

        [HttpPut("/increase")]
        public ActionResult IncreasePointBalance(BalanceChange change)
        {
            _PointService.IncreaseBalance(change.customerId, change.amount);
            return Ok();
        }

        [HttpPut("/decrease")]
        public ActionResult DecreasePointBalance(BalanceChange change)
        {
            _PointService.DecreaseBalance(change.customerId, change.amount);
            return Ok();
        }
    }
}
