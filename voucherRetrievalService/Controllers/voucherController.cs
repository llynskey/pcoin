using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using voucherRetrievalService.Models;
using voucherRetrievalService.Services;
using System.Text.Json;
using MongoDB.Bson;

namespace voucherRetrievalService.Controllers
{
    [Route("/")]
    [ApiController]
    public class voucherController : ControllerBase
    {
        private readonly voucherService _voucherService;

        public voucherController(voucherService voucherService)
        {
            _voucherService = voucherService;
        }

        [HttpGet("byId")]
        public ActionResult<Voucher> getvoucher(string id){
            var ID = ObjectId.Parse(id);
            Voucher voucher = _voucherService.Get(id);
            return Ok(voucher);
        }

        [HttpGet]
        public ActionResult<List<Voucher>> getvouchers()
        {
            List<Voucher> vouchers = _voucherService.Get();
            var json = JsonSerializer.Serialize(vouchers);
            return Ok(vouchers);
        }

        [HttpGet("offeredBy")]
        public ActionResult getVouchersOfferedByVenue(string venueId)
        {
            List<Voucher> vouchers = _voucherService.GetByVenueId(venueId);
            return Ok(vouchers);
        }

        [HttpGet("ownedBy")]
        public ActionResult getVouchersOwnedByVendor(string vendorId)
        {
            List<Voucher> vouchers = _voucherService.GetByOwnerId(vendorId);
            return Ok(vouchers);
        }

    }
}
