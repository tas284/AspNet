using API.Data.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Abstract;

public abstract class Document : IDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    public DateTime CreatedAt { get; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
