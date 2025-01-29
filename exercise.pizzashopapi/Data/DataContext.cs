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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseNpgsql(connectionString);


            //set primary of order?

            //seed data?
            
            

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasKey(x => x.orderId);
            modelBuilder.Entity<Customer>()
            .HasMany(c => c.Orders)
            .WithOne(o => o.Customer).
            HasForeignKey(o => o.customerId);

            modelBuilder.Entity<Order>()
                .HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.productId); 

            modelBuilder.Entity<OrderToppings>()
                .HasKey(ot => new { ot.OrderId, ot.ToppingId });

            modelBuilder.Entity<OrderToppings>()
                .HasOne(ot => ot.Order)
                .WithMany(o => o.toppings)
                .HasForeignKey(ot => ot.OrderId);

            modelBuilder.Entity<OrderToppings>()
                .HasOne(ot => ot.Topping)
                .WithMany(t => t.OrderToppings)
                .HasForeignKey(ot => ot.ToppingId);
        }

        


        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Toppings> Toppings { get; set; }
        public DbSet<OrderToppings> OrderToppings { get; set; }
    }
}
