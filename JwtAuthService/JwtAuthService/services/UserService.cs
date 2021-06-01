using System;
using JwtAuthService.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthService.services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.CollectionName);
        }

        public List<User> Get() =>
            _users.Find(user => true).ToList();

        public User Get(string username) =>
            _users.Find<User>(user => user.Username == username).FirstOrDefault();
        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }
    }
}
 