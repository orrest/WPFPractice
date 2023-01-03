using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDBCRUD.Services;

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
}