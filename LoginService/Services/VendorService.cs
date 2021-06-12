using System.Collections.Generic;
using System.Linq;
using LoginService.Models;
using MongoDB.Driver;

namespace LoginService.Services
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

        public Vendor Get(string username) =>
            _vendors.Find<Vendor>(vendor => vendor.Username == username).FirstOrDefault();
        public Vendor Create(Vendor vendor)
        {
            _vendors.InsertOne(vendor);
            return vendor;
        }
    }
}
