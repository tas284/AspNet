namespace API.Data.DTO;

public class OrderDTO
{
    public int code { get; set; }
    public string? CustomerID { get; set; }
    public List<ProductDTO>? Products { get; set; }
    public string? Status { get; set; }
    public double Total { get; set; }
    public double Discount { get; set; }
    public DateTime AppointmentTime { get; set; }
    public DateTime EndTime { get; set; }
}