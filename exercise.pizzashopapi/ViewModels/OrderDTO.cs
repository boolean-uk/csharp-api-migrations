using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.ViewModels
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public CustomerDTO Customer { get; set; }
        public PizzaDTO Pizza { get; set; }

        public OrderDTO(Order order, List<Customer> customers, List<Pizza> pizzas)
        {
            this.Id = order.Id;

            foreach (var customer in customers)
            {
                if (order.CustomerId == customer.Id)
                {
                    Customer = new CustomerDTO(customer);
                    break;
                }
            }

            foreach(var pizza in pizzas)
            {
                if(order.PizzaId == pizza.Id)
                {
                    Pizza = new PizzaDTO(pizza);
                    break;
                }
            }
        }
    }
}
