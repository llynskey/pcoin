﻿using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using customerManagementService.Models;
using MongoDB.Bson;

namespace customerManagementService.Services
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
            public bool Create(Customer customer)
            {
                _customers.InsertOne(customer);
                return true;
            }

            public Customer Edit(Customer customer)
            {
            var filter = Builders<Customer>.Filter.Eq("_id",customer._id);
            //var update = Builders<BsonDocument>.Update.Combine(customer);
            _customers.ReplaceOne(filter, customer);
            return customer;    
        }
      }
 }
