using System.Collections.Generic;
using System.Linq;
using venueRetrievalService.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace venueRetrievalService.Services
{
    public class venueService
    {
        private readonly IMongoCollection<Venue> _venues;

        public venueService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _venues = database.GetCollection<Venue>(settings.CollectionName);
        }

        public List<Venue> Get() =>
            _venues.Find<Venue>(venue => true).ToList<Venue>();

        public List<Venue> GetByOwnerId(string ownerId)
        {
            System.Console.WriteLine("Owner Id: "+ownerId);
            return _venues.Find<Venue>(venue => venue.ownerId == ownerId).ToList<Venue>();
        }
        public Venue Get(string _id)
        {
          System.Console.WriteLine(_id);
          return _venues.Find<Venue>(venue => venue._id == _id).FirstOrDefault();
        }
    }
}
