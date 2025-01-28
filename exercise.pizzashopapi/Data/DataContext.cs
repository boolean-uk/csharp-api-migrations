using System.Diagnostics;
using exercise.pizzashopapi.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.Data;

public class DataContext : DbContext
{
    private readonly string _connectionString;

    public DataContext()
    {
        var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
    }

    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Topping> Toppings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .HasKey(o => o.Id);
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId);
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Pizza)
            .WithMany()
            .HasForeignKey(o => o.PizzaId);
        modelBuilder.Entity<Order>()
            .HasMany(o => o.Toppings)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "OrderToppings",
                r => r.HasOne<Topping>().WithMany().HasForeignKey("ToppingId"),
                l => l.HasOne<Order>().WithMany().HasForeignKey("OrderId")
            );
        modelBuilder.Entity<Customer>()
            .HasKey(c => c.Id);
        modelBuilder.Entity<Pizza>()
            .HasKey(p => p.Id);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
        optionsBuilder.LogTo(message => Debug.WriteLine(message));
    }
}