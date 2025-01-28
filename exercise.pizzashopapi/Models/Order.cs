using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models;

public class Order
{
    public int Id { get; set; }

    public int PizzaId { get; set; }
    public Pizza Pizza { get; set; }

    public IEnumerable<OrderToppings> OrderToppings { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public int DeliveryDriverId { get; set; }
    public DeliveryDriver DeliveryDriver { get; set; }

    public OrderWithoutCustomer WithoutCustomer()
    {
        return new OrderWithoutCustomer()
        {
            Id = this.Id,
            PizzaId = this.PizzaId,
            Pizza = this.Pizza,

            OrderToppings = this.OrderToppings.Select(ot => ot.WithoutOrder()),

            DeliveryDriverId = this.DeliveryDriverId,
            DeliveryDriver = this.DeliveryDriver.ToShallow(),
        };
    }

    public OrderWithoutDriver WithoutDriver()
    {
        return new OrderWithoutDriver()
        {
            Id = this.Id,
            PizzaId = this.PizzaId,
            Pizza = this.Pizza,

            OrderToppings = this.OrderToppings.Select(ot => ot.WithoutOrder()),

            CustomerId = this.CustomerId,
            Customer = this.Customer.ToShallow(),
        };
    }

    public OrderGetDto ToGetDto()
    {
        return new OrderGetDto()
        {
            Id = this.Id,

            PizzaId = this.PizzaId,
            Pizza = this.Pizza,
            OrderToppings = this.OrderToppings.Select(ot => ot.WithoutOrder()),

            CustomerId = this.CustomerId,
            Customer = this.Customer.ToShallow(),

            DeliveryDriverId = this.DeliveryDriverId,
            DeliveryDriver = this.DeliveryDriver.ToShallow(),
        };
    }
}
