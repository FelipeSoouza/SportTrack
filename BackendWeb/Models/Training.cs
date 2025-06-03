using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebSport.Models
{
    public class Training
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }

        public string Date { get; set; }

        public string Sport { get; set; }

        public string Notes { get; set; }
    }
}
