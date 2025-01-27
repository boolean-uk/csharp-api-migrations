using System.Text.Json.Serialization;

namespace exercise.pizzashopapi.DTO;

public class OrderResponse
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public CustomerResponse? Customer { get; set; }
    public PizzaResponse Pizza { get; set; }
}