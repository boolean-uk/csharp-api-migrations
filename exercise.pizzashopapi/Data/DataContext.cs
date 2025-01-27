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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Set up composite key for Order (pizzaId+customerId)
        //    modelBuilder.Entity<Order>()
        //        .HasKey(o => new { o.PizzaId, o.CustomerId });

        //    modelBuilder.Entity<Order>()
        //        .HasOne(o => o.Pizza)
        //        .WithMany(p => p.Orders)
        //        .HasForeignKey(o => o.PizzaId);

        //    modelBuilder.Entity<Order>()
        //       .HasOne(o => o.Customer)
        //       .WithMany(p => p.Orders)
        //       .HasForeignKey(o => o.CustomerId);

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseNpgsql(connectionString);

            //set primary of order?

            //seed data?

        }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
