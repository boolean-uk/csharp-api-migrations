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
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.UseLazyLoadingProxies();

            //set primary of order?

            //seed data?
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>().HasKey(p => p.Id);
            modelBuilder.Entity<Customer>().HasKey(c => c.Id);
            modelBuilder.Entity<Order>().HasKey(o => o.Id);
            modelBuilder.Entity<Topping>().HasKey(t => t.Id);
            modelBuilder.Entity<OrderToppings>().HasKey(ot => ot.Id);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Pizza)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.PizzaId);
            
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderToppings)
                .WithOne(ot => ot.Order)
                .HasForeignKey(ot => ot.OrderId);

            modelBuilder.Entity<Pizza>()
                .HasMany(p => p.Orders)
                .WithOne(o => o.Pizza);

            modelBuilder.Entity<OrderToppings>()
                .HasOne(ot => ot.Order)
                .WithMany(o => o.OrderToppings)
                .HasForeignKey(ot => ot.OrderId);

            modelBuilder.Entity<OrderToppings>()
                .HasOne(ot => ot.Topping)
                .WithMany(t => t.OrderToppings)
                .HasForeignKey(ot => ot.ToppingId);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderToppings)
                .WithOne(ot => ot.Order);

            DateTime exampleDate = new DateTime(2021, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            //Seed pizza, customers and Toppings
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza { Id = 1, Name = "Pepperoni", Price = 10.00m, CreatedAt = exampleDate, UpdatedAt = exampleDate },
                new Pizza { Id = 2, Name = "Cheese", Price = 8.00m, CreatedAt = exampleDate, UpdatedAt = exampleDate },
                new Pizza { Id = 3, Name = "Mushrooms", Price = 9.00m, CreatedAt = exampleDate, UpdatedAt = exampleDate }
            );
            

            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "John Doe", CreatedAt = exampleDate, UpdatedAt = exampleDate },
                new Customer { Id = 2, Name = "Jane Doe", CreatedAt = exampleDate, UpdatedAt = exampleDate }
            );

            modelBuilder.Entity<Topping>().HasData(
                new Topping { Id = 1, Price = 5, Name = "Pepperoni", CreatedAt = exampleDate, UpdatedAt = exampleDate },
                new Topping { Id = 2, Price = 6, Name = "Cheese", CreatedAt = exampleDate, UpdatedAt = exampleDate },
                new Topping { Id = 3, Price = 7, Name = "Mushrooms", CreatedAt = exampleDate, UpdatedAt = exampleDate }
                
            );
            
        }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Topping> Toppings {get;set;}
        public DbSet<OrderToppings> OrderToppings {get;set;}
    }
}
