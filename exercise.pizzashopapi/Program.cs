using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.EndPoints;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IRepository<Pizza>, Repository<Pizza>>();
builder.Services.AddScoped<IRepository<Customer>, Repository<Customer>>();
builder.Services.AddScoped<IRepository<Order>, Repository<Order>>();
builder.Services.AddScoped<OrderRepository>();
builder.Services.AddDbContext<DataContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin() // Allow requests from any origin
              .AllowAnyMethod() // Allow all HTTP methods
              .AllowAnyHeader(); // Allow any headers
    });
});

var app = builder.Build();

app.UseCors("AllowAllOrigins");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.ConfigurePizzaShopApi();

app.SeedPizzaShopApi();
app.Run();
