using System.Text.Json.Serialization;

namespace API.Data.DTO;

public class ProductDTO
{
    public string? Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public string? Brand { get; set; }
    [JsonIgnore]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}