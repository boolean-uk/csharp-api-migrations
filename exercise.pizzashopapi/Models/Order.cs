using System.ComponentModel.DataAnnotations.Schema;
using exercise.pizzashopapi.DTO;

namespace exercise.pizzashopapi.Models
{
    public class Order
    {
        public int Id { get; set; }
        
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
        public IEnumerable<OrderToppings> OrderToppings { get; set; }

        public int DeliveryDriverId { get; set; }
        public DeliveryDriver DeliveryDriver { get; set; }

        public OrderWithoutCustomer NoCustomer()
        {
            return new OrderWithoutCustomer()
            {
                Id = this.Id,
                PizzaId = this.PizzaId,
                Pizza = this.Pizza,

                OrderToppings = this.OrderToppings.Select(ot => ot.NoOrder()),

                DeliveryDriverId = this.DeliveryDriverId,
                DeliveryDriver = this.DeliveryDriver.ToDTO()
            };
        }
        public OrderWithoutDriver NoDriver()
        {
            return new OrderWithoutDriver()
            {
                Id = this.Id,
                PizzaId = this.PizzaId,
                Pizza = this.Pizza,

                OrderToppings = this.OrderToppings.Select(ot => ot.NoOrder()),

                CustomerId = this.CustomerId,
                Customer = this.Customer.GetSmall()
            };
        }
        public OrderWithoutTopping NoTopping()
        {
            return new OrderWithoutTopping()
            {
                Id = this.Id,
                PizzaId = this.PizzaId,
                Pizza = this.Pizza,

                CustomerId = this.CustomerId,
                Customer = this.Customer.GetSmall(),

                DeliveryDriverId = this.DeliveryDriverId,
                DeliveryDriver = this.DeliveryDriver.ToDTO()
            };
        }
        public OrderDTO ToGetDto()
        {
            return new OrderDTO()
            {
                Id = this.Id,

                PizzaId = this.PizzaId,
                Pizza = this.Pizza,
                OrderToppings = this.OrderToppings.Select(ot => ot.NoOrder()),

                CustomerId = this.CustomerId,
                Customer = this.Customer.GetSmall(),

                DeliveryDriverId = this.DeliveryDriverId,
                DeliveryDriver = this.DeliveryDriver.ToDTO(),
            };
        }
    }
}
