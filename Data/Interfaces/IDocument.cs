using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Data.Interfaces;

public interface IDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; set; }
}