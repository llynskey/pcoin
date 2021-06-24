using System;
using Microsoft.AspNetCore.Mvc;
using pointRetrievalService.Models;
using pointRetrievalService.Services;

namespace pointRetrievalService.Controllers
{
    [Route("/")]
    [ApiController]
    public class pointController : ControllerBase
    {
        private readonly PointService _pointService;

        public pointController(PointService PointService)
        {
            _pointService = PointService;
        }

        [HttpGet]
        public ActionResult getPoint(string id){
            PointAccount Point = _pointService.Get(id);
            if (Point != null)
            {
                return Ok(Point);
            }
            else
            {
                return NotFound("Point account Not Found");
            }
        }

    }
}
