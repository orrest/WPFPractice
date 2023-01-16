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

        public async Task<Book> GetBookByNameAsync(string name)
        {
            var filter = Builders<Book>.Filter.Eq(b => b.Name, name);

            var db = _client.GetDatabase("library");
            var cl = db.GetCollection<Book>("magazines");
            var book = await cl.FindAsync<Book>(filter);
            return book.FirstOrDefault<Book>();
        }
    }

    public class Book
    {
        [BsonElement]
        public string Name { get; set; }

        [BsonElement]
        public bool Sold { get; set; }
    }
}
