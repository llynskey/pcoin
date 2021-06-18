using System.Collections.Generic;
using System.Linq;
using vendorRetrievalService.Models;
using MongoDB.Driver;

namespace vendorRetrievalService.Services
{
    public class VendorService
    {
        private readonly IMongoCollection<Vendor> _vendors;

        public VendorService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _vendors = database.GetCollection<Vendor>(settings.CollectionName);
        }

        public List<Vendor> Get() =>
            _vendors.Find(vendor => true).ToList();

        public Vendor Get(string _id) =>
            _vendors.Find<Vendor>(vendor => vendor._id == _id).FirstOrDefault();
    }
}
