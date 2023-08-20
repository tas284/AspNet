namespace API.Data.DTO;

public class OrderDTO
{
    public int Code { get; set; }
    public CustomerDTO? Customer { get; set; }
    public List<OrderItemDTO>? Products { get; set; }
    public string? Status { get; set; }
    public double Total { get; set; }
    public double Discount { get; set; }
    public DateTime AppointmentTime { get; set; }
    public DateTime EndTime { get; set; }
}