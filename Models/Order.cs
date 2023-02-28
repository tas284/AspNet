using API.Abstract;
using API.Data.Repositories;

namespace API.Data.Models;

[BsonCollection("Orders")]
public class Order : Document
{
    public int code { get; set; }
    public string? CustomerID { get; set; }
    public List<Product>? Products { get; set; }
    public double Total { get; set; }
    public double Discount { get; set; }
    public DateTime AppointmentTime { get; set; }
    public DateTime EndTime { get; set; }
}