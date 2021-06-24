using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using venueRetrievalService.Models;
using venueRetrievalService.Services;
using System.Text.Json;
using MongoDB.Bson;

namespace venueRetrievalService.Controllers
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

        [HttpGet]
        public ActionResult<Venue> getvenue(string id){
            Venue venue = _venueService.Get(id);
            return Ok(venue);
        }

        [HttpGet("/all")]
        public ActionResult<List<Venue>> getvenues()
        {
            List<Venue> venues = _venueService.Get();
            return Ok(venues);
        }

        [HttpGet("/byOwner")]
        public ActionResult getVendorVenues(string ownerId)
        {
            List<Venue> venues = _venueService.GetByOwnerId(ownerId);
            return Ok(venues);
        }


    }
}
