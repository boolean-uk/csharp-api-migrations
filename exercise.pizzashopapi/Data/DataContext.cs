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
            connectionString = configuration.GetValue<string>(
                "ConnectionStrings:DefaultConnectionString"
            );
            this.Database.EnsureCreated();
            this.Database.SetConnectionString(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>().HasKey(b => b.Id);

            modelBuilder.Entity<Customer>().HasKey(b => b.Id);
            modelBuilder
                .Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<Order>().HasKey(b => b.Id);
            modelBuilder
                .Entity<Order>()
                .HasOne(o => o.Pizza)
                .WithMany()
                .HasForeignKey(o => o.PizzaId);
            modelBuilder
                .Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);
            modelBuilder
                .Entity<Order>()
                .HasMany(o => o.OrderToppings)
                .WithOne(t => t.Order)
                .HasForeignKey(a => a.OrderId);

            modelBuilder.Entity<DeliveryDriver>().HasKey(b => b.Id);
            modelBuilder
                .Entity<DeliveryDriver>()
                .HasMany(d => d.Orders)
                .WithOne(o => o.DeliveryDriver)
                .HasForeignKey(o => o.DeliveryDriverId);

            modelBuilder.Entity<OrderToppings>().HasKey(b => b.Id);
            modelBuilder
                .Entity<OrderToppings>()
                .HasOne(ot => ot.Topping)
                .WithMany()
                .HasForeignKey(a => a.ToppingId);

            modelBuilder.Entity<Topping>().HasKey(b => b.Id);
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
        public DbSet<DeliveryDriver> DeliveryDrivers { get; set; }
        public DbSet<OrderToppings> OrderToppings { get; set; }
        public DbSet<Topping> Toppings { get; set; }
    }
}
