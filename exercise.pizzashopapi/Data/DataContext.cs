using System.Numerics;
using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.Data
{
    public class DataContext : DbContext
    {
        private string connectionString;
        public DataContext()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString");

        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseNpgsql(connectionString);
            //set primary of order?

            //seed data?

        }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<OrderToppings> OrderToppings { get; set; }
        public DbSet<DeliveryDriver> DeliveryDrivers { get; set; }
    }
}
