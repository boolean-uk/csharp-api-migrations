using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Data
{
    public class Seeder
    {
        private List<Pizza> _pizzas = new List<Pizza>();
        private List<Customer> _customers = new List<Customer>();
        private List<Order> _orders = new List<Order>();

        public Seeder()
        {
            //Pizzas
            Pizza pizza1 = new Pizza();
            pizza1.Id = 1;
            pizza1.Name = "Ham and Cheese";
            pizza1.Price = 120.0m;

            Pizza pizza2 = new Pizza();
            pizza2.Id = 2;
            pizza2.Name = "Spicy Peperoni";
            pizza2.Price = 140m;

            Pizza pizza3 = new Pizza();
            pizza3.Id = 3;
            pizza3.Name = "Vegan Garden";
            pizza3.Price = 110m;

            _pizzas.Add(pizza1);
            _pizzas.Add(pizza2);
            _pizzas.Add(pizza3);

            //Customer
            Customer customer1 = new Customer();
            customer1.Id = 1;
            customer1.Name = "Anders Panders";

            Customer customer2 = new Customer();
            customer2.Id = 2;
            customer2.Name = "Nigel Teacherman";

            Customer customer3 = new Customer();
            customer3.Id = 3;
            customer3.Name = "Dave Davidson";

            _customers.Add(customer1);
            _customers.Add(customer2);
            _customers.Add(customer3);

            Order order1 = new Order();
            order1.CustomerId = 1;
            order1.PizzaId = 2;
            order1.OrderedAt = DateTime.UtcNow;
            order1.PizzaStatus = "Preparing";

            Order order2 = new Order();
            order2.PizzaId = 3;
            order2.CustomerId = 2;
            order2.OrderedAt = DateTime.UtcNow;
            order2.PizzaStatus = "Preparing";

            _orders.Add(order1);
            _orders.Add(order2);
        }

        public List<Pizza> Pizzas { get { return _pizzas; } }
        public List<Customer> Customers { get { return _customers; } }
        public List<Order> Orders { get { return _orders; } }
    }
}
