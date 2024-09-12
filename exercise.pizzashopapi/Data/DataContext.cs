using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
               new Customer { Id = 1, Name = "Nigel" },
               new Customer { Id = 2, Name = "Dave" }
            );

            modelBuilder.Entity<Pizza>().HasData(
                new Pizza { Id = 1, Name = "Cheese & Pineapple", Price = 10 },
                new Pizza { Id = 2, Name = "Vegan Cheese Tastic", Price = 13 }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, CustomerId = 1, PizzaId = 2 },
                new Order { Id = 2, CustomerId = 2, PizzaId = 1 }
            );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
