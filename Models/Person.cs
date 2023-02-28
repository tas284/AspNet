using API.Abstract;
using API.Data.Repositories;

namespace API.Data.Models;

[BsonCollection("People")]
public class Person : Document
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
}