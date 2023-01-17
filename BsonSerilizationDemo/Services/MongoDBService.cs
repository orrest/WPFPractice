using BsonSerilizationDemo.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
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

        public async Task<Magazine> GetMagazineByNameAsync(string name)
        {
            var filter = Builders<Magazine>.Filter.Eq(b => b.Name, name);

            var db = _client.GetDatabase("library");
            var cl = db.GetCollection<Magazine>("magazines");
            var book = await cl.FindAsync<Magazine>(filter);
            return book.FirstOrDefault<Magazine>();
        }

        public void PutBookAsync()
        {
            var db = _client.GetDatabase("library");
            var cl = db.GetCollection<Book>("books");
            cl.InsertOneAsync(new Book { ISBN = "I AM AN ISBN", Name = "I AN A NAME"});
        }
    }
}
