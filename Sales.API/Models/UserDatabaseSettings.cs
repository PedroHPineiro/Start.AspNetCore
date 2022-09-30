using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Sales.API.Models;

public class UserDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string UserCollectionName { get; set; } = null!;
}