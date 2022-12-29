
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Diagnostics;

namespace MongoDBCRUD.Services;

public class MongoDBSerivce
{
    private readonly ConnectionStrings _secrets;
    private readonly MongoClient _client;

    public MongoDBSerivce(IOptions<ConnectionStrings> secrets)
	{
        _secrets = secrets.Value;

        string connStr = _secrets.MongoDB;
        _client = new MongoClient(connStr);
    }

    public async void GetDatabaseNamesAsync()
    {
        var databases = await _client.ListDatabaseNamesAsync();
        var databasesList = databases.ToList();
        foreach (var item in databasesList)
        {
            Debug.WriteLine(item);
        }
    }
}