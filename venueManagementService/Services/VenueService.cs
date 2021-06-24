using System.Collections.Generic;
using System.Linq;
using venueManagementService.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace venueManagementService.Services
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

        public Venue Create(Venue venue)
        {
            _venues.InsertOne(venue);
            return venue;
        }

        public Venue Edit(string venueId,Venue venue)
        {
            var filter = Builders<Venue>.Filter.Eq("_id", venueId);
            _venues.ReplaceOne(filter, venue);
            return venue;
        }

        public void Delete(string venueId)
        {
            var filter = Builders<Venue>.Filter.Eq("_id", venueId);
            _venues.DeleteOne(filter);
        }

        public void AddVoucher(string venueId ,Voucher voucher)
        {
           var venue = _venues.Find(venue => venue._id == venueId).FirstOrDefault();
          // venue.vouchers.addVoucher(voucher);
           venue.ToBsonDocument().ToJson();
            System.Console.WriteLine(venue);
           var filter = Builders<Venue>.Filter.Eq("_id", venueId);
            _venues.ReplaceOne(filter, venue);
        }


    }
}
