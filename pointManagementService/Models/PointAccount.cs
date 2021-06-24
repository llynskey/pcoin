using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace pointManagementService.Models
{
    public class PointAccount
    {
        public PointAccount(string ownerId, int balance)
        {
           this.ownerId = ownerId;
            this.Balance = balance;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String _id { get; set; }

        public String ownerId { get; set; }

        public int Balance { get; set; }


    }
}
