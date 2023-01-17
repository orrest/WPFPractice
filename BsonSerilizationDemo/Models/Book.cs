using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BsonSerilizationDemo.Models
{
    public record Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("ISBN")]
        public string ISBN { get; set; }
    }
}
