using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BsonSerilizationDemo.Services
{
    public class MongoDBSerivce
    {
        private readonly ConnectionStrings _secrets;
        private readonly MongoClient _client;

        public MongoDBSerivce(IOptions<ConnectionStrings> secrets)
        {
            _secrets = secrets.Value;

            try
            {
                string connStr = _secrets.MongoDB;
                _client = new MongoClient(connStr);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task<List<BsonDocument>> GetDatabaseNamesAsync()
        {
            var databases = await _client.ListDatabasesAsync();

            return databases.ToList();
        }

        public async Task<Magzine> GetMagazineByNameAsync(string name)
        {
            var filter = Builders<Magzine>.Filter.Eq(b => b.Name, name);

            var db = _client.GetDatabase("library");
            var cl = db.GetCollection<Magzine>("magazines");
            var book = await cl.FindAsync<Magzine>(filter);
            return book.FirstOrDefault<Magzine>();
        }

        public void PutBookAsync()
        {
            var db = _client.GetDatabase("library");
            var cl = db.GetCollection<Book>("books");
            cl.InsertOneAsync(new Book { ISBN = "I AM AN ISBN", Name = "I AN A NAME"});
        }
    }
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("ISBN")]
        public string ISBN { get; set; }
    }

    public class Magzine
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
