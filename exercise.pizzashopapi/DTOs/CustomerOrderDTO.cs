namespace exercise.pizzashopapi.DTOs;

public class CustomerOrderDTO(DateTime orderDate, string pizzaName, decimal pizzaPrice)
{
    public string OrderDate { get; set; } = orderDate.ToString("HH:mm:ss dd.MM.yy");
    public string PizzaName { get; set; } = pizzaName;
    public string PizzaPrice { get; set; } = pizzaPrice + "kr";
}