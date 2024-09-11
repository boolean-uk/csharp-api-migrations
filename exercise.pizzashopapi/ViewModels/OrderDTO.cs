using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.ViewModels
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public CustomerDTO Customer { get; set; }
        public PizzaDTO Pizza { get; set; }
        public string Status { get; set; }
        public string TimeLeft { get; set; }
        public OrderDTO(Order order, List<Customer> customers, List<Pizza> pizzas)
        {
            this.Id = order.Id;
            //Status
            if (order.Status == OrderStatus.Preparing)
            {
                this.Status = "Preparing";
            }
            else if (order.Status == OrderStatus.Cooking)
            {
                this.Status = "Cooking";
            }
            else if (order.Status == OrderStatus.Transporting)
            {
                this.Status = "Transporting";
            }
            else
            {
                this.Status = "Delivered";
            }
            //Time
            string minutes = $"{(int)Math.Floor((order.TimeLeft.TotalSeconds / 60))}";
            string seconds = $"{(int)(order.TimeLeft.TotalSeconds % 60)}";
            if(minutes.Count() == 1)
            {
                minutes = minutes.Insert(0, "0");
            }
            if (seconds.Count() == 1)
            {
                seconds = seconds.Insert(0, "0");
            }
            this.TimeLeft = $"{minutes}:{seconds}m"; //Example 03:32m

            //Customer
            foreach (var customer in customers)
            {
                if (order.CustomerId == customer.Id)
                {
                    Customer = new CustomerDTO(customer);
                    break;
                }
            }

            //Pizza
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
