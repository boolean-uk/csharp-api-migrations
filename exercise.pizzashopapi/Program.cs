using System.Numerics;
using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.EndPoints;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using exercise.pizzashopapi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddOpenApi();
builder.Services.AddDbContext<DataContext>(options =>
{
    var connectionString = configuration.GetConnectionString("DefaultConnectionString");
    options.UseNpgsql(connectionString);

    options.ConfigureWarnings(warnings =>
        warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
});

builder.Services.AddScoped<IRepository<Customer, int>, Repository<Customer, int>>();
builder.Services.AddScoped<IRepository<Product, int>, Repository<Product, int>>();
builder.Services.AddScoped<IRepository<Order, int>, Repository<Order, int>>();
builder.Services.AddScoped<IRepository<Topping, int>, Repository<Topping, int>>();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.ConfigureProductsEndpoints();
app.ConfigureCustomersEndpoints();
app.ConfigureOrdersEndpoints();
app.ConfigureToppingsEndpoints();

app.Run();
