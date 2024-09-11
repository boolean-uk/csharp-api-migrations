namespace exercise.pizzashopapi.DTOs;

public class OrderDTO(DateTime orderDate, string customerName, string pizzaName, decimal pizzaPrice)
{
    public string OrderDate { get; set; } = orderDate.ToString("HH:mm:ss dd.MM.yy");
    public string TimeNow { get; set; } = DateTime.UtcNow.ToString("HH:mm:ss dd.MM.yy");
    public string CustomerName { get; set; } = customerName;
    public string PizzaName { get; set; } = pizzaName;
    public string PizzaPrice { get; set; } = pizzaPrice + "kr";
    public string Status { get; set; } = GetOrderStatus(orderDate);

    private static string GetOrderStatus(DateTime orderDate)
    {
        var minutesElapsed = (DateTime.UtcNow - orderDate).TotalMinutes;
        if (minutesElapsed <= 2) return "Preparing!";
        if (minutesElapsed <= 15) return "In the oven!";
        return "Finished!";
    }
}