using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;

namespace exercise.pizzashopapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Pizza>()
              .HasKey(p => p.Id);

            modelBuilder.Entity<Pizza>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();


            Pizza pizza1 = new Pizza { Id = 1, Name = "Pepperoni", Price = 200 };
            Pizza pizza2 = new Pizza { Id = 2, Name = "Cheese", Price = 150 };
            Pizza pizza = new Pizza { Id = 3, Name = "Chicken", Price = 175 };

            Customer customer = new Customer { Id = 1, Name = "Mike Johnson" };
            Customer customer2 = new Customer { Id = 2, Name = "Amy Smith" };
            Customer customer3 = new Customer { Id = 3, Name = "Alan Rogers" };

            Order order1 = new Order { Id = 1,
                CustomerId = 1,
                OrderDate = DateOnly.FromDateTime(DateTime.Today),
                PizzaId = 1,
                orderState = "In Delivery",
                delivered = false};
            Order order2 = new Order { Id = 2,
                CustomerId = 2,
                OrderDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-1)),
                PizzaId = 2,
                orderState = "In Oven",
                delivered = false};
            Order order3 = new Order
            {
                Id = 3,
                CustomerId = 3,
                OrderDate = DateOnly.FromDateTime(DateTime.Today.AddDays(2)),
                PizzaId = 3,
                orderState = "Arrived",
                delivered = true
            };


            modelBuilder.Entity<Pizza>().HasData(pizza,pizza2,pizza1);
            modelBuilder.Entity<Customer>().HasData(customer, customer2, customer3);
            modelBuilder.Entity<Order>().HasData(order1, order2, order3);
        }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
