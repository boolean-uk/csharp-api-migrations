using System.Diagnostics;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Order>().HasKey(o => new { o.CustomerId, o.PizzaId });
            modelBuilder.Entity<Order>().HasOne(o => o.Customer).WithMany(c => c.Orders).HasForeignKey(o => o.CustomerId);
            modelBuilder.Entity<Order>().HasOne(p => p.Pizza).WithMany(p =>p.Orders).HasForeignKey(o => o.PizzaId);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 3, Name = "Johhny" },
                new Customer { Id = 4, Name = "Gunnar" }
                );

            modelBuilder.Entity<Pizza>().HasData(
                new Pizza { Id = 3, Name = "Pepperoni", Price = 8.99m },
                new Pizza { Id = 4, Name = "BBQ chicken", Price = 10.99m }
                );

            modelBuilder.Entity<Order>().HasData(
             new Order { CustomerId = 1, PizzaId = 2 },
             new Order { CustomerId = 2, PizzaId = 1 }
             );

            modelBuilder.Entity<Order>().HasData(
                new Order { CustomerId = 3, PizzaId = 4 },
                new Order { CustomerId = 4, PizzaId = 3 }
                );

            modelBuilder.Entity<Customer>().HasData(
               new Customer { Id = 8, Name = "Håkon" }
               );

            modelBuilder.Entity<Pizza>().HasData(
                new Pizza { Id = 9, Name = "Meatlover", Price = 12.99m }
                );

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseNpgsql(connectionString);

            //set primary of order?
            optionsBuilder.LogTo(message => Debug.WriteLine(message));

            //seed data?

        }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
