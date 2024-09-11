using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;

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
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Initializing seeder
            Seeder seeder = new Seeder();

            // Declaring compisite order key
            modelBuilder.Entity<Order>().HasKey(o => new { o.PizzaId, o.CustomerId });

            // Seeding entities
            modelBuilder.Entity<Customer>().HasData(seeder.Customers);
            modelBuilder.Entity<Pizza>().HasData(seeder.Pizzas);
            modelBuilder.Entity<Order>().HasData(seeder.Orders);
        }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
