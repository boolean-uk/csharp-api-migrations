using exercise.pizzashopapi.Models;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace exercise.pizzashopapi.Data
{
    public class Seeder
    {
        private List<string> _firstnames = new List<string>()
        {
            "Patrick",
            "Sandy",
            "Princess",
            "Spongebob",
            "Knuckles",
            "Donkey",
            "Luigi",
            "Sonic",
            "Mario",
            "Yoshi"
        };
        private List<string> _lastnames = new List<string>()
        {
            "Star",
            "Cheeks",
            "Peach",
            "Daisy",
            "the Echidna",
            "Kong",
            "Mario",
            "the Dinosaur",
            "the Hedgehog",
            "Squarepants"
        };
        private List<string> _pizzaFirst = new List<string>()
        {
            "Cheese",
            "Depression",
            "Candy",
            "Dirt",
            "Grass",
            "Mold",
            "Tomato",
            "Concrete"
        };

        private List<string> _pizzaSecond = new List<string>()
        {
            "",
            " & Cheese",
            " & Ketchup",
            " & Sardine",
            " & California Reaper",
            " & Expired Milk",
            " & Despair"
        };

        private List<Customer> _customers = new List<Customer>();
        private List<Pizza> _pizzas = new List<Pizza>();
        private List<Order> _orders = new List<Order>();

        public Seeder()
        {
            Random customerRandom = new Random();
            Random pizzaRandom = new Random();
            Random orderRandom = new Random();

            for(int x = 1; x < 16; x++)
            {
                Customer customer = new Customer();
                customer.Id = x;
                customer.Name = $"{_firstnames[customerRandom.Next(_firstnames.Count)]} {_lastnames[customerRandom.Next(_lastnames.Count)]}";
                _customers.Add(customer);
            }

            for(int y = 1; y < 16; y++)
            {
                Pizza pizza = new Pizza();
                pizza.Id = y;
                pizza.Name = $"{_pizzaFirst[pizzaRandom.Next(_pizzaFirst.Count)]}{_pizzaSecond[pizzaRandom.Next(_pizzaSecond.Count)]} Pizza";
                pizza.Price = pizzaRandom.Next(8, 20);
                _pizzas.Add(pizza);
            }

            for(int z= 1; z < 16; z++)
            {
                Order order = new Order();
                order.Id = z;
                order.CustomerId = _customers[z - 1].Id;
                order.PizzaId = _pizzas[z - 1].Id;
                order.Status = (OrderStatus)orderRandom.Next(0, 3);
                if (order.Status == OrderStatus.Preparing)
                {
                    order.TimeLeft = TimeSpan.FromSeconds(orderRandom.Next(1, 180)); //1 second to 3 minutes
                }
                else if (order.Status == OrderStatus.Cooking)
                {
                    order.TimeLeft = TimeSpan.FromSeconds(orderRandom.Next(1, 720)); //1 second to 12 minutes
                }
                else if (order.Status == OrderStatus.Transporting)
                {
                    order.TimeLeft = TimeSpan.FromSeconds(orderRandom.Next(1, 600)); //1 second to 10 minutes
                }
                else
                {
                    order.TimeLeft = TimeSpan.Zero;
                }
                _orders.Add(order);
            }
        }

        public List<Customer> customers { get { return _customers; } }
        public List<Pizza> pizzas { get { return _pizzas; } }
        public List<Order> orders { get { return _orders; } }
    }
}
