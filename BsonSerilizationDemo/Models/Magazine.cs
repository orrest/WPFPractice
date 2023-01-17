using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BsonSerilizationDemo.Models
{
    public record Magazine
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("sold")]
        public bool Sold { get; set; }
    }
}
