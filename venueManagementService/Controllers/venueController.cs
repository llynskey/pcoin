using Microsoft.AspNetCore.Mvc;
using venueManagementService.Models;
using venueManagementService.Services;

namespace venueManagementService.Controllers
{
    [Route("/")]
    [ApiController]
    public class venueController : ControllerBase
    {
        private readonly venueService _venueService;
    
        public venueController(venueService venueService)
        {
            _venueService = venueService;
        } 

        [HttpPost]
        public ActionResult<Venue> CreateVenue(Venue venue)
        {
            _venueService.Create(venue);
            return Ok();
        }

        [HttpPut]
        public ActionResult<Venue> UpdateVenue(Venue venue)
        {
            _venueService.Edit(venue._id, venue);
            return Ok();
        }

        [HttpDelete]
        public ActionResult<Venue> DeleteVenue(Venue venue)
        {
            _venueService.Delete(venue._id);
            return Ok();
        }
    }
}
