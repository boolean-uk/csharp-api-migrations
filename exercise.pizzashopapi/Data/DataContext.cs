using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace exercise.pizzashopapi.Data
{
    public class DataContext : DbContext
    {
        private string _connectionString;
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message)); //see the sql EF using in the console
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Keys
            modelBuilder.Entity<Order>().HasKey(o => new { o.CustomerId, o.PizzaId });

            modelBuilder.Entity<Order>().HasOne(o => o.Customer).WithMany(c => c.Orders).HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<Order>().HasOne(o => o.Pizza).WithMany(p => p.Orders).HasForeignKey(o => o.PizzaId);

            //Seeder
            Seeder seeder = new Seeder();

            //Data
            modelBuilder.Entity<Customer>().HasData(seeder.customers);
            modelBuilder.Entity<Pizza>().HasData(seeder.pizzas);
            modelBuilder.Entity<Order>().HasData(seeder.orders);
        }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
