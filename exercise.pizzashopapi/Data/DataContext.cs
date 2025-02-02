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
                .HasKey(a => a.Id);
            modelBuilder.Entity<Pizza>()
                .HasKey(a => a.Id);
            modelBuilder.Entity<Order>()
                .HasKey(a => a.Id);

            //defining relations
            modelBuilder.Entity<Customer>()
                .HasMany(a => a.Orders)
                .WithOne(a => a.customer)
                .HasForeignKey(a => a.Id);

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

            //seeding


        }

 
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
