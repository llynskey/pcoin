using System.Collections.Generic;
using System.Linq;
using vendorManagementService.Models;
using MongoDB.Driver;

namespace vendorManagementService.Services
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

        public Vendor Create(Vendor vendor)
        {
            _vendors.InsertOne(vendor);
            return vendor;
        }

        public Vendor Edit(Vendor vendor)
        {
            var filter = Builders<Vendor>.Filter.Eq("_id", vendor._id);
            //var update = Builders<BsonDocument>.Update.Combine(customer);
            _vendors.ReplaceOne(filter, vendor);
            return vendor;
        }
    }
}
