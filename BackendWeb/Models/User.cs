﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebSport.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Sport { get; set; }
    }
}
