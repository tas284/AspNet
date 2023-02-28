using System.Text.Json.Serialization;

namespace API.Data.DTO;

public class PersonDTO
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    [JsonIgnore]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}