using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace voucherRetrievalService.Models
{
    public class Voucher
    {
       [BsonId]
       [BsonRepresentation(BsonType.ObjectId)]
       public String _id { get; set; }
       public String ownerId { get; set; }
       public string Name { get; set; }
       public int Price { get; set; }
       public List<string> OfferedBy { get; set; }
    }
}
