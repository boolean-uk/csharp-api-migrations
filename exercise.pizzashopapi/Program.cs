using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.EndPoints;
using exercise.pizzashopapi.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Legg til tjenester i DI-containeren
builder.Services.AddControllers(); // Legger til støtte for kontroller
builder.Services.AddScoped<IRepository, Repository>(); // Registrer repository
builder.Services.AddDbContext<DataContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
    options.UseNpgsql(connectionString);
});

// Legg til Swagger for API-dokumentasjon
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Utfør migrasjoner og seeding ved oppstart
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();

    // Kjør migrasjoner for å sikre at databasen er oppdatert
    dbContext.Database.Migrate();

    // Seed data hvis databasen er tom
    var seeder = new Seeder();
    if (!dbContext.Pizzas.Any() && !dbContext.Customers.Any() && !dbContext.Orders.Any())
    {
        var pizzas = seeder.GetPizzas();
        var customers = seeder.GetCustomers();
        var orders = seeder.GetOrders(pizzas, customers);

        dbContext.Pizzas.AddRange(pizzas);
        dbContext.Customers.AddRange(customers);
        dbContext.Orders.AddRange(orders);

        await dbContext.SaveChangesAsync();
    }
}

// Konfigurer middleware og HTTP-pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers(); // Mapper kontrollerne som API-endepunkter

PizzaShopApi.ConfigurePizzaShopApi(app);
// Kjør applikasjonen
app.Run();
