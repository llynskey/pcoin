using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using customerRetrievalService.Models;

namespace customerRetrievalService.Services
{
        public class CustomerService
        {
            private readonly IMongoCollection<Customer> _customers;

            public CustomerService(IDatabaseSettings settings)
            {
                var client = new MongoClient(settings.ConnectionString);
                var database = client.GetDatabase(settings.DatabaseName);

                _customers = database.GetCollection<Customer>(settings.CollectionName);
            }

            public List<Customer> Get() =>
                _customers.Find(customer => true).ToList();

        public Customer Get(string _id) =>
            _customers.Find<Customer>(customer => customer._id == _id).FirstOrDefault();
        }
 }
