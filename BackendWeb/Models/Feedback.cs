using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WebSport.Models;

public class Feedback
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? UserId { get; set; }

    public string? Date { get; set; }

    [BsonElement("comment")]
    public string? Comment { get; set; }

    public string? Sport { get; set; }
}
