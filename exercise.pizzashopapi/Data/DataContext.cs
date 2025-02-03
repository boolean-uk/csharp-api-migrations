using api_cinema_challenge.Models;
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
            connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
            this.Database.SetConnectionString(connectionString);
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString);
            optionsBuilder.UseLazyLoadingProxies();

            //set primary of order?

            //seed data?

        }
        protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {
            //defining primary keys
            modelBuilder.Entity<Customer>()
                .HasKey(a => a.customerId);
            modelBuilder.Entity<Pizza>()
                .HasKey(a => a.pizzaId);
            modelBuilder.Entity<Order>()
                .HasKey(a => a.orderId);
            modelBuilder.Entity<Topping>()
                .HasKey(a => a.toppingId);
            modelBuilder.Entity<OrderToppings>()
                .HasKey(a => a.orderToppingId);


            //defining relations
            modelBuilder.Entity<Customer>()
                .HasMany(a => a.Orders)
                .WithOne(a => a.customer)
                .HasForeignKey(a => a.customerId);

            modelBuilder.Entity<Pizza>()
               .HasMany(a => a.Orders)
               .WithOne(a => a.pizza);
               

            modelBuilder.Entity<Order>()
               .HasOne(a => a.pizza)
               .WithMany(a => a.Orders)
               .HasForeignKey(a => a.pizzaId);


            modelBuilder.Entity<Order>()
               .HasOne(a => a.customer)
               .WithMany(a => a.Orders)
               .HasForeignKey(a => a.customerId);

            modelBuilder.Entity<Order>()
               .HasMany(a => a.OrderToppings)
               .WithOne(a => a.order);
               

            modelBuilder.Entity<OrderToppings>()
             .HasOne(a => a.order)
             .WithMany(a => a.OrderToppings)
             .HasForeignKey(a => a.orderId);

            modelBuilder.Entity<OrderToppings>()
             .HasOne(a => a.topping)
             .WithMany(a => a.orderToppings)
             .HasForeignKey(a => a.toppingId);

            modelBuilder.Entity<Topping>()
             .HasMany(a => a.orderToppings)
             .WithOne(a => a.topping);
            
            //seeding


        }

 
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderToppings> OrderToppings { get; set; }
        public DbSet<Topping> Toppings { get; set; }

    }
}
