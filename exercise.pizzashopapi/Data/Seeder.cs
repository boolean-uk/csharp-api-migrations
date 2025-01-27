using System;
using exercise.pizzashopapi.Models;

public class Seeder
{
    private List<string> _firstnames = new List<string>()
    {
        "Audrey", "Donald", "Elvis", "Barack", "Oprah",
        "Jimi", "Mick", "Kate", "Charles", "Kate"
    };

    private List<string> _lastnames = new List<string>()
    {
        "Hepburn", "Trump", "Presley", "Obama", "Winfrey",
        "Hendrix", "Jagger", "Winslet", "Windsor", "Middleton"
    };

    private List<string> _pizzaNames = new List<string>()
    {
        "Cheese & Pineapple", "Vegan Cheese Tastic", "Pepperoni", "Margherita", "Hawaiian",
        "Vegetarian", "Meat Lovers", "BBQ Chicken", "Buffalo", "Supreme"
    };

    private List<Customer> _customers = new List<Customer>();
    private List<DeliveryDriver> _drivers = new List<DeliveryDriver>();
    private List<Pizza> _pizzas = new List<Pizza>();
    private List<Order> _orders = new List<Order>();

    public Seeder()
    {
        for (int i = 1; i <= 10; i++)
        {
            Customer customer = new Customer
            {
                Id = i,
                Name = $"{_firstnames[i % _firstnames.Count]} {_lastnames[i % _lastnames.Count]}"
            };
            _customers.Add(customer);
        }

        for (int i = 1; i <= 2; i++)
        {
            DeliveryDriver driver = new DeliveryDriver
            {
                Id = i,
                Name = $"{_firstnames[i % _firstnames.Count]} {_lastnames[i % _lastnames.Count]}"
            };
            _drivers.Add(driver);
        }

        for (int i = 1; i <= 10; i++)
        {
            
            Pizza pizza = new Pizza
            {
                Id = i,
                Name = _pizzaNames[i % _pizzaNames.Count],
                Price = 50,
            };
            _pizzas.Add(pizza);
        }
        for (int i = 1; i <= 20; i++)
        {
            var customer = _customers[i % _customers.Count];
            var pizza = _pizzas[i % _pizzas.Count];

            Order order = new Order
            {
                Id = i,
                CustomerId = customer.Id,
                PizzaId = pizza.Id,
                OrderTime = new DateTime(2023, 12, 25).AddDays(i).ToUniversalTime(),
                Status = exercise.pizzashopapi.OrderStatus.Complete,
                PizzaStatus = exercise.pizzashopapi.PizzaStatus.Finished
            };
            _orders.Add(order);
        }
    }

    public List<Customer> Customers => _customers;
    public List<DeliveryDriver> DeliveryDrivers => _drivers;
    public List<Pizza> Pizzas => _pizzas;
    public List<Order> Orders => _orders;
}
