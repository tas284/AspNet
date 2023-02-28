using API.Data.Models;

namespace API.Data.DTO;

public class OrderDTO
{
    public int code { get; set; }
    public string? CustomerID { get; set; }
    public List<Product>? Products { get; set; }
    public double Total { get; set; }
    public double Discount { get; set; }
    public DateTime AppointmentTime { get; set; }
    public DateTime EndTime { get; set; }
}