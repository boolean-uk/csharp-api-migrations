using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.Data
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderTopping>().HasKey(ot => new { ot.OrderId, ot.ToppingId });
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Toppings)
                .WithMany(t => t.Orders)
                .UsingEntity<OrderTopping>();
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Product)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.ProductId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.SetNull);

            Seeder seeder = new Seeder();
            modelBuilder.Entity<Customer>().HasData(seeder.Customers);
            modelBuilder.Entity<Product>().HasData(seeder.Products);
            modelBuilder.Entity<Order>().HasData(seeder.Orders);
            modelBuilder.Entity<Topping>().HasData(seeder.Toppings);
            modelBuilder.Entity<OrderTopping>().HasData(seeder.OrderToppings);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Topping> Toppings { get; set; }
    }
}
