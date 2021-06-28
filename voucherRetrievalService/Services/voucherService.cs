using System.Collections.Generic;
using System.Linq;
using voucherRetrievalService.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using System;

namespace voucherRetrievalService.Services
{
    public class voucherService
    {
        private readonly IMongoCollection<Voucher> _vouchers;

        public voucherService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _vouchers = database.GetCollection<Voucher>(settings.CollectionName);
        }

        public List<Voucher> Get() =>
            _vouchers.Find(voucher => true).ToList();

        public Voucher Get(string _id)
        {
            System.Console.WriteLine(_id);
            return _vouchers.Find<Voucher>(voucher => voucher._id == _id).FirstOrDefault();
        }

        public List<Voucher> GetByVenueId(string venueId)
        {
            return _vouchers.Find<Voucher>(voucher => voucher.OfferedBy.Contains(venueId)).ToList<Voucher>();
        }

        public List<Voucher> GetByOwnerId(string ownerId)
        {
            return _vouchers.Find<Voucher>(voucher => voucher.ownerId.Contains(ownerId)).ToList<Voucher>();
        }
    }
}
