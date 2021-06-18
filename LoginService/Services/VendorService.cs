using System.Collections.Generic;
using System.Linq;
using LoginService.Models;
using MongoDB.Driver;

namespace LoginService.Services
{
    public class VendorService
    {
        private readonly IMongoCollection<Vendor> _vendors;

        public VendorService(IVendorDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _vendors = database.GetCollection<Vendor>(settings.CollectionName);
        }

        public Vendor Get(string username) =>
            _vendors.Find<Vendor>(vendor => vendor.Username == username).FirstOrDefault();
    }
}
