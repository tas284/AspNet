namespace API.Data.Models;

public class OrderItem
{
    public string Id { get; set; } = null!;
    public string? Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public string? Brand { get; set; }
    public bool Status { get; set; }
}