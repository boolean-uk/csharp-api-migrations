using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.EndPoints;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IRepository<Customer>, Repository<Customer>>();
builder.Services.AddScoped<IRepository<Order>, Repository<Order>>();
builder.Services.AddScoped<IRepository<Pizza>, Repository<Pizza>>();
builder.Services.AddScoped<IRepository<Topping>, Repository<Topping>>();
builder.Services.AddScoped<IRepository<OrderTopping>, Repository<OrderTopping>>();
builder.Services.AddDbContext<DatabaseContext>();

builder.Services.AddHostedService<OrderStatusUpdaterService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.ConfigurePizzaShopEndpoint();

app.SeedPizzaShopApi();

app.Run();
