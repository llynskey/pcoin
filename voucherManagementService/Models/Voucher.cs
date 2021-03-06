﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace voucherManagementService.Models
{
    public class Voucher
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String _id { get; set; }
        public String ownerId { get; set; }
        public String Name { get; set; }
        public int Price { get; set; }
        public List<String> OfferedBy {get; set;}

        
    }
}
