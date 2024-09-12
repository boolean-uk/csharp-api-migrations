using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Data
{
    public class Seeder
    {

        private List<Order> _orders = new List<Order>();
        private List<Pizza> _pizzas = new List<Pizza>();
        private List<Customer> _customers = new List<Customer>();



        public Seeder() { 
             
                    _customers.Add(new Customer() { Id = 1, Name="Nigel" });
                    _customers.Add(new Customer() { Id = 2, Name = "Dave" });                
              
                    _pizzas.Add(new Pizza() { Id = 1, Name = "Cheese & Pineapple", Price = 8 });
                    _pizzas.Add(new Pizza() { Id = 2, Name = "Vegan Cheese Tastic", Price = 2 });
                
                    _orders.Add(new Order () { CustomerId = 1, PizzaId = 2});
                    _orders.Add(new Order() { CustomerId = 2, PizzaId = 1});                
            }
        

        public List<Order> Orders { get { return _orders; } }
        public List<Customer> Customers { get { return _customers; } }
        public List<Pizza> Pizzas { get { return _pizzas; } }

    }
}
