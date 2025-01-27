using System.Numerics;
using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace exercise.pizzashopapi.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnectionString"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Seeder seed = new Seeder();

            modelBuilder.Entity<Order>()
               .HasOne(o => o.Pizza) 
               .WithMany()
               .HasForeignKey(p => p.PizzaId) 
               .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer) 
                .WithMany()             
                .HasForeignKey(o => o.CustomerId) 
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Order>()
               .HasOne(o => o.DeliveryDriver)
               .WithMany(d => d.Orders)
               .HasForeignKey(o => o.DeliveryDriverId)
               .OnDelete(DeleteBehavior.SetNull);


            modelBuilder.Entity<Customer>().HasData(seed.Customers);
            modelBuilder.Entity<DeliveryDriver>().HasData(seed.DeliveryDrivers);
            modelBuilder.Entity<Order>().HasData(seed.Orders);
            modelBuilder.Entity<Pizza>().HasData(seed.Pizzas);



        }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DeliveryDriver> DeliveryDrivers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
