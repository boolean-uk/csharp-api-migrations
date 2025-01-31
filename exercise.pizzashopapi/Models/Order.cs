using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    [Table("orders")]
    public class Order
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public Pizza Pizza { get; set; }
        public Customer Customer { get; set; }
        public List<OrderToppings> ToppingOrders { get; set; }

        public Order() { }
        public Order(int pizzaId, int customerId, Pizza pizza, Customer customer)
        {
            PizzaId = pizzaId;
            CustomerId = customerId;
            Pizza = pizza;
            Customer = customer;
            CreatedAt = DateTime.Now;
        }
    }
}
