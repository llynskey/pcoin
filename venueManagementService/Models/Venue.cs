﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace venueManagementService.Models
{
    public class Venue 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String _id { get; set; }

        public string ownerId { get; set; }

        public string name { get; set; }

        public string address { get; set; }

        public string city { get; set; }
    }
}