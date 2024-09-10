using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
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
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //relationships
            modelBuilder.Entity<Order>().HasKey(i => new { i.CustomerId, i.PizzaId });


            //seed data
            Seeder seeder = new Seeder();
            modelBuilder.Entity<Pizza>().HasData(seeder.Pizzas);
            modelBuilder.Entity<Order>().HasData(seeder.Orders);
            modelBuilder.Entity<Customer>().HasData(seeder.Customers);
        }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
