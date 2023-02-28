using API.Abstract;
using API.Data.Repositories;

namespace API.Data.Models;

[BsonCollection("Products")]
public class Product : Document
{
    public string? Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; } = 0;
    public string? Brand { get; set; }
}