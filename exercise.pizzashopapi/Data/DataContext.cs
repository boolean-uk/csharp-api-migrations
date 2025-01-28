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

            modelBuilder.Entity<Pizza>().
                HasKey(p => new { p.Id });
            
            modelBuilder.Entity<Customer>().
                HasKey(p => new { p.Id });
            
            modelBuilder.Entity<Order>().
                HasKey(p => new { p.Id});
            
            modelBuilder.Entity<Topping>().
                HasKey(p => new { p.Id });
            
            modelBuilder.Entity<OrderToppings>().
                HasKey(p => new { p.Id });


            modelBuilder.Entity<OrderToppings>().
                HasOne(p => p.Topping).
                WithMany(p => p.OrderToppings).
                HasForeignKey(p => p.ToppingId);


            modelBuilder.Entity<OrderToppings>().
                HasOne(p => p.Order).
                WithMany(o => o.OrderToppings).
                HasForeignKey(p => new { p.OrderId});

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
    }
}
