using System.Text.Json.Serialization;
using exercise.pizzashopapi.Enums;

namespace exercise.pizzashopapi.DTO;

public class OrderResponse
{
    public int Id { get; set; }
    public string Status { get; set; }
    public DateTime OrderDate { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public CustomerResponse? Customer { get; set; }
    public PizzaResponse Pizza { get; set; }
    public IEnumerable<string> Toppings { get; set; } = new List<string>();
}