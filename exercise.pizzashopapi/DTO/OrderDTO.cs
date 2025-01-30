using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }

        public IEnumerable<OrderToppingWithoutOrderDTO> OrderToppings { get; set; }

        public int CustomerId { get; set; }
        public CustomerDTO Customer { get; set; }

        public int DeliveryDriverId { get; set; }
        public DeliveryDriverDTO DeliveryDriver { get; set; }
    }
    public class OrderWithoutCustomer
    {
        public int Id { get; set; }

        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }

        public IEnumerable<OrderToppingWithoutOrderDTO> OrderToppings { get; set; }

        public int DeliveryDriverId { get; set; }
        public DeliveryDriverDTO DeliveryDriver { get; set; }
    }

    public class OrderWithoutDriver
    {
        public int Id { get; set; }

        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }

        public IEnumerable<OrderToppingWithoutOrderDTO> OrderToppings { get; set; }

        public int CustomerId { get; set; }
        public CustomerDTO Customer { get; set; }
    }
    public class OrderWithoutTopping
    {
        public int Id { get; set; }

        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
        public int CustomerId { get; set; }
        public CustomerDTO Customer { get; set; }
        public int DeliveryDriverId { get; set; }
        public DeliveryDriverDTO DeliveryDriver { get; set; }
    }
}
