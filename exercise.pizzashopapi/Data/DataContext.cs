using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace exercise.pizzashopapi.Data
{
    public class DataContext : DbContext
    {
        private string connectionString;
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Pizza> Pizzas = new List<Pizza>();
            List<Customer> Customers = new List<Customer>();
            List<Order> Orders = new List<Order>();

            Pizza pizza = new Pizza() { Id = 1, Name = "Mexicano", Price = 250.0m };
            Pizza pizza1 = new Pizza() { Id = 2, Name = "Pepperoni", Price = 240.0m };
            Pizzas.Add(pizza);
            Pizzas.Add(pizza1);

            Customer customer = new Customer() { Id = 1, Name = "Øyvind" };
            Customer customer1 = new Customer() { Id = 2, Name = "Test" };
            Customers.Add(customer);
            Customers.Add(customer1);

            Order order = new Order() { Id = 1, pizzaID = 1, customerId = 1 };
            Order order1 = new Order() { Id = 2, pizzaID = 2, customerId = 2};

            Orders.Add(order);
            Orders.Add(order1);

            modelBuilder.Entity<Pizza>().HasData(Pizzas);
            modelBuilder.Entity<Customer>().HasData(Customers);
            modelBuilder.Entity<Order>().HasData(Orders);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseNpgsql(connectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message));

        }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
