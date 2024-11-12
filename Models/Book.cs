using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDbApi.Models;

public class Book
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    [BsonElement("Title")]
    public string Title { get; set; } = null!;

    [BsonElement("Author")]
    public string Author { get; set; } = null!;

    public int Pages { get; set; }
}
