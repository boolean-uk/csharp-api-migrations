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
            connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //set primary of order?
            modelBuilder.Entity<Order>().HasKey(k => new { k.PizzaId, k.CustomerId });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseNpgsql(connectionString);
        }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
