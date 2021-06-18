﻿using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AccountService.Models
{
    public class User
    { 
        [BsonId]
        public String _id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Username { get; set; }
        public String Pass { get; set; }    
    } 
}