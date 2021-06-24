using System.Collections.Generic;
using System.Linq;
using pointRetrievalService.Models;
using MongoDB.Driver;

namespace pointRetrievalService.Services
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

        public List<PointAccount> Get() =>
            _points.Find(point => true).ToList();

        public PointAccount Get(string id) =>
            _points.Find<PointAccount>(point => point.ownerId == id).FirstOrDefault();
    }
}
