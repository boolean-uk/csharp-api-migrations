using System;

namespace exercise.pizzashopapi.DTOs;

public class OrderDTO
{
    public int Id { get; set; }
    public CustomerDTO Customer { get; set; }
    public PizzaDTO Pizza { get; set; }
    public List<OrderToppingDTO> OrderToppings { get; set; }
    

}


public class CreateOrderDTO
{
    public int CustomerId { get; set; }
    public int PizzaId { get; set; }
    public List<int> Toppings { get; set; }
}