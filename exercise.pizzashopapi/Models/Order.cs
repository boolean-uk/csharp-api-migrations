using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.pizzashopapi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public int CustomerId { get; set; }

        public Pizza Pizza { get; set; }
        public Customer Customer { get; set; }

        public Order() { }
        public Order(int pizzaId, int customerId, Pizza pizza, Customer customer)
        {
            PizzaId = pizzaId;
            CustomerId = customerId;
            Pizza = pizza;
            Customer = customer;
        }
    }
}
