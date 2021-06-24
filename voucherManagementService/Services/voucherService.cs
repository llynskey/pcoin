using System.Collections.Generic;
using System.Linq;
using voucherManagementService.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace voucherManagementService.Services
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

        public Voucher Create(Voucher voucher)
        {
            _vouchers.InsertOne(voucher);
            return voucher;
        }

        public Voucher Edit(string voucherId,Voucher Voucher)
        {
            var filter = Builders<Voucher>.Filter.Eq("_id", voucherId);
            _vouchers.ReplaceOne(filter, Voucher);
            return Voucher;
        }



    }
}
