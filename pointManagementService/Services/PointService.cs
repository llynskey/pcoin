using System.Collections.Generic;
using System.Linq;
using pointManagementService.Models;
using MongoDB.Driver;

namespace pointManagementService.Services
{
    public class PointService
    {
        private readonly IMongoCollection<PointAccount> _points;

        public PointService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _points = database.GetCollection<PointAccount>(settings.CollectionName);
        }

        public bool CreateAccount(string customerId)
        {
            PointAccount pointAccount = new PointAccount(customerId, 0);
            if (_points.Find(pointAccount => pointAccount.ownerId == customerId).Any())
            {
                return false;
            }
            else
            {
                _points.InsertOne(pointAccount);
                return true;
            }
        }

        public void IncreaseBalance(string customerId, int amount)
        {
            var filter = Builders<PointAccount>.Filter.Eq("ownerId", customerId);
            var update = Builders<PointAccount>.Update.Inc("Balance", amount);
            _points.FindOneAndUpdate<PointAccount>(filter, update);
        }

        public void DecreaseBalance(string customerId, int amount)
        {
            var filter = Builders<PointAccount>.Filter.Eq("ownerId", customerId);
            var update = Builders<PointAccount>.Update.Inc("Balance", -amount);
            _points.FindOneAndUpdate<PointAccount>(filter, update);
        }
    }
}
