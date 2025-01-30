using System.Numerics;
using System.Reflection.Emit;
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
            var connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            this.Database.SetConnectionString(connectionString);
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Appointment Key etc.. Add Here

            modelBuilder.Entity<Customer>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Customer>()
                .HasMany(o => o.Orders)
                .WithOne(c => c.Customer)
                .HasForeignKey(d => d.CustomerId);

            modelBuilder.Entity<DeliveryDriver>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Order>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Order>()
                .HasOne(p => p.Pizza)
                .WithMany()
                .HasForeignKey(d => d.PizzaId);
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(d => d.CustomerId);
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderToppings)
                .WithOne(t => t.Order)
                .HasForeignKey(a => a.OrderId);

            modelBuilder.Entity<Pizza>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Topping>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<OrderToppings>()
                .HasOne(t => t.Topping)
                .WithMany()
                .HasForeignKey(t => t.ToppingId);

            modelBuilder.Entity<OrderToppings>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<DeliveryDriver>()
                .HasMany(o => o.Orders)
                .WithOne(d => d.DeliveryDriver)
                .HasForeignKey(o => o.DeliveryDriverId);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseNpgsql(connectionString);
        }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<DeliveryDriver> DeliveryDrivers { get; set; }
        public DbSet<OrderToppings> OrderToppings { get; set; }
        public DbSet<Topping> Toppings { get; set; }
    }
}
