using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Data
{
    public class Seeder
    {
        private List<string> _pizzaNames = new List<string>
        {
            "Cheese & Pineapple",
            "Vegan Cheese Tastic",
            "Pepperoni Feast",
            "BBQ Chicken Delight",
            "Margarita Supreme",
            "Four Seasons",
            "Meat Lover's Special",
            "Spicy Veggie",
            "Garlic Mushroom",
            "Buffalo Ranch"
        };

        private List<string> _customerNames = new List<string>
        {
            "Nigel",
            "Dave",
            "Alice",
            "Bob",
            "Charlie",
            "Diana",
            "Edward",
            "Fiona",
            "George",
            "Hannah"
        };

        public List<Pizza> GetPizzas()
        {
            Random random = new Random();
            var pizzas = new List<Pizza>();

            for (int i = 1; i <= _pizzaNames.Count; i++)
            {
                pizzas.Add(new Pizza
                {
                    Id = i,
                    Name = _pizzaNames[i - 1],
                    Price = random.Next(100, 500) // Random price between 100 and 500
                });
            }
            return pizzas;
        }

        public List<Customer> GetCustomers()
        {
            var customers = new List<Customer>();

            for (int i = 1; i <= _customerNames.Count; i++)
            {
                customers.Add(new Customer
                {
                    Id = i,
                    Name = _customerNames[i - 1]
                });
            }
            return customers;
        }

        public List<Order> GetOrders(List<Pizza> pizzas, List<Customer> customers)
        {
            var orders = new List<Order>();
            Random random = new Random();
            int orderId = 1;

            for (int i = 1; i <= 20; i++) // Create 20 random orders
            {
                var randomPizza = pizzas[random.Next(pizzas.Count)];
                var randomCustomer = customers[random.Next(customers.Count)];

                orders.Add(new Order
                {
                    Id = orderId++,
                    PizzaId = randomPizza.Id,
                    CustomerId = randomCustomer.Id
                });
            }

            return orders;
        }
    }
}



