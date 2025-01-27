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
            modelBuilder.Entity<Pizza>().HasKey(p => p.Id);
            modelBuilder.Entity<Customer>().HasKey(c => c.Id);

            modelBuilder.Entity<Order>().HasKey(o => new { o.PizzaId, o.CustomerId });
            modelBuilder.Entity<Order>().HasKey(o => o.Id);
            modelBuilder.Entity<Topping>().HasKey(t => t.Id);
            modelBuilder.Entity<OrderToppings>().HasKey(ot => new { ot.OrderId, ot.ToppingId });
            modelBuilder.Entity<OrderToppings>().HasKey(o => o.Id);
            modelBuilder.Entity<DeliveryDriver>().HasKey(d => d.Id);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseNpgsql(connectionString);
        }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<OrderToppings> OrderToppings { get; set; }
        public DbSet<DeliveryDriver> DeliveryDrivers { get; set; }
    }
}
