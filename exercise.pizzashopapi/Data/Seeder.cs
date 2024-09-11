using exercise.pizzashopapi.Models;
using System.Numerics;

namespace exercise.pizzashopapi.Data
{
    public class Seeder
    {
        private List<Order> _orders = new List<Order>();
        private List<Pizza> _pizzas = new List<Pizza>();
        private List<Customer> _customers = new List<Customer>();
        public Seeder() 
        {
            _customers.Add(new Customer() { Name="Nigel", Id = 1 });
            _customers.Add(new Customer() { Name = "Dave", Id = 2 });
            _customers.Add(new Customer() { Name = "Felix" , Id= 3});
                    
               
            _pizzas.Add(new Pizza() { Name = "Cheese & Pineapple" , Id = 1 , Price = 8});
            _pizzas.Add(new Pizza() { Name = "Vegan Cheese Tastic", Id = 2, Price = 2});
            _pizzas.Add(new Pizza() { Name = "Kebab & Pommes Frites", Id = 3, Price = 5}); //kebabpizza is the most popular pizza in Sweden

            for(int i = 1; i < 4; i++)
            {
                _orders.Add(new Order(i, i)
                {
                    Id = i
                }); // i i, Captain!
            }
        }

        public List<Order> Orders { get { return _orders; } }
        public List<Pizza> Pizzas { get { return _pizzas; } }
        public List<Customer> Customers { get { return _customers; } }
    }
}
