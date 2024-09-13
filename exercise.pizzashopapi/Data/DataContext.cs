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

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasKey(o => new { o.PizzaId, o.CustomerId });

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Pizza)
                .WithOne(p => p.Order)
                .HasForeignKey<Order>(o => o.PizzaId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithOne(c => c.Order)
                .HasForeignKey<Order>(o => o.CustomerId);

            // SEED
            /*
            modelBuilder.Entity<Pizza>().HasData
                (
                 new Pizza() { Id = 1, Name = "Cheese & Pineapple", Price = 50 },
                 new Pizza() { Id = 2, Name = "Vegan Cheese Tastic", Price = 70 },
                 new Pizza() { Id = 3, Name = "Dobbel Pepperoni", Price = 100 }
                );

            modelBuilder.Entity<Customer>().HasData
                (
                    new Customer() { Id = 1, Name = "Nigel" },
                    new Customer() { Id = 2, Name = "Dave" },
                    new Customer() { Id = 3, Name = "Dennis" }
                );

            modelBuilder.Entity<Order>().HasData
               (
                    new Order() { CustomerId = 1, PizzaId = 1, OrderTime = DateTime.UtcNow, Status = "Preparing" },
                    new Order() { CustomerId = 2, PizzaId = 2, OrderTime = DateTime.UtcNow + TimeSpan.FromMinutes(4), Status = "Delivering" },
                    new Order() { CustomerId = 3, PizzaId = 3, OrderTime = DateTime.UtcNow + TimeSpan.FromMinutes(20), Status = "Delivered" },
                    new Order() { CustomerId = 1, PizzaId = 3, OrderTime = DateTime.UtcNow + TimeSpan.FromMinutes(5), Status = "Deliviring" }
                );
            */
        }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
