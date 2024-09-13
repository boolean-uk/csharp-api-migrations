using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace exercise.pizzashopapi.Data
{
    public class DataContext : DbContext
    {
        private string _connectionString;
        public DataContext()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString");

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message)); //see the sql EF using in the console
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasKey(a => new { a.PizzaId, a.CustomerId });

        }



        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
