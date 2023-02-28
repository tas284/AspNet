using API.Data.Interfaces;

namespace API.Data.Repositories;

public class MongoDbSettings : IMongoDbSettings
{
    public string? DatabaseName { get; set; }
    public string? ConnectionString { get; set; }
}