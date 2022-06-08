using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models;

public class TodoItem {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id {get; set;} // ? - make it nullable
    public string Title {get; set;}
    public bool IsCompleted {get; set;}
}

