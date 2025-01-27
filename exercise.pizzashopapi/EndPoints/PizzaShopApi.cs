using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using exercise.pizzashopapi.Utils;
using Microsoft.AspNetCore.Mvc;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
                var shop = app.MapGroup("/shop");

            shop.MapGet("/pizzas", GetPizzas);
            shop.MapGet("/customers", GetCustomers);
            shop.MapGet("/orders", GetOrders);
            shop.MapGet("/orders/{customerId}", GetOrdersByCustomerId);
            shop.MapPost("/orders", CreateOrder);
            shop.MapPost("/customers", CreateCustomer);
            shop.MapPost("/pizzas", CreatePizza);
            shop.MapGet("/pizzas/{id}", GetPizzaById);
            shop.MapGet("/toppings/{id}", GetTopping);
            shop.MapGet("/toppings", GetToppings);
            shop.MapPost("/orders/{orderId}", DeliverOrder);
            shop.MapGet("drivers/{driverId}/orders", GetOrdersByDriverId);
            shop.MapPut("/orders/{orderId}/{driverId}", AssignOrderToDriver);
        }

        private static async Task<IResult> GetPizzas(IRepository<Pizza> repository)
        {
            var pizzas = await repository.Get();
            return TypedResults.Ok(pizzas.Select(p => 
            new PizzaDto() {
                Name = p.Name,
                Price = p.Price
            }));
        }

        private static async Task<IResult> GetCustomers(IRepository<Customer> repository)
        {
            var customers = await repository.Get();
            return TypedResults.Ok(customers.Select(c => 
            new CustomerDto() {
                Name = c.Name
            }));
        }

        private static async Task<IResult> GetOrders(IRepository<Order> repository)
        {
            var orders = await repository.GetWithIncludes(o => o.Customer, o => o.Pizza);
            return TypedResults.Ok(orders.Select(o => new OrderDto()
            {
                Customer = o.Customer.Name,
                Pizza = o.Pizza.Name,
                OrderedAt = o.OrderedAt,
                Price = o.Price,
                Stage = o.OrderedAt.GetPizzaStage().GetPizzaStageString(),
                EstimatedDelivery = DeliveryEngine.GetEstimatedDeliveryInMinutes(orders, o.Id)
            }));
        }

        private static async Task<IResult> GetOrdersByCustomerId(IRepository<Order> repository, int customerId)
        {
        
            var orders = await repository.GetWithIncludes(o => o.Customer, o => o.Pizza);
            return TypedResults.Ok(orders.Where(o => o.CustomerId == customerId).Select(o => new OrderDto()
            {
                Customer = o.Customer.Name,
                Pizza = o.Pizza.Name,
                OrderedAt = o.OrderedAt,
                Price = o.Price,
                Stage = o.OrderedAt.GetPizzaStage().GetPizzaStageString(),
                EstimatedDelivery = DeliveryEngine.GetEstimatedDeliveryInMinutes(orders, o.Id)
            }));
        }

        private static async Task<IResult> CreateOrder(IRepository<Order> repository, IRepository<Pizza> pizzaRepository, IRepository<Topping> toppingRepository, CreateOrderDto orderDto)
        {
            var pizza = await pizzaRepository.GetById(orderDto.PizzaId);
            var orders = await repository.Get();
            if (pizza == null)
            {
                return TypedResults.NotFound();
            }
            var order = new Order()
            {
                CustomerId = orderDto.CustomerId,
                PizzaId = orderDto.PizzaId,
                OrderedAt = DateTime.UtcNow,
                Price = pizza.Price
            };
            orderDto.ToppingIds.ForEach(async toppingId =>
            {
                Topping thisTopping = await toppingRepository.GetById(toppingId);
                var orderTopping = new OrderToppings()
                {
                    ToppingId = toppingId,
                };
                order.OrderToppings.Add(orderTopping);
                order.Price += thisTopping.Price;
                order.Toppings.Add(thisTopping);
            });
            var orderedPizza = await repository.Insert(order);
            var pizzaWithIncludes = await repository.GetByIdWithIncludes(orderedPizza.Id, o => o.Customer, o => o.Pizza, o => o.Toppings);
            CreatedOrderDto createdOrder = new CreatedOrderDto()
            {
                Customer = pizzaWithIncludes.Customer.Name,
                Pizza = pizzaWithIncludes.Pizza.Name,
                OrderedAt = pizzaWithIncludes.OrderedAt,
                Price = pizzaWithIncludes.Price,
                IsDelivered = pizzaWithIncludes.IsDelivered,
                EstimatedDelivery = DeliveryEngine.GetEstimatedDeliveryInMinutes(orders, orderedPizza.Id),
                Toppings = pizzaWithIncludes.Toppings.Select(t => new ToppingDto()
                {
                    Name = t.Name,
                    Price = t.Price
                })
            };
            return TypedResults.Created("apath", createdOrder);

        }

        private static async Task<IResult> UpdateOrder(IRepository<Order> repository, int orderId, UpdateOrderDto orderDto)
        {
            var order = await repository.GetById(orderId);
            if (order == null)
            {
                return TypedResults.NotFound();
            }
            if(orderDto.IsDelivered != null)
                order.IsDelivered = orderDto.IsDelivered;
            if(orderDto.Price != null)
                order.Price = orderDto.Price;
            var updatedOrder = await repository.Update(order);
            OrderDto responseDto = new OrderDto()
            {
                Customer = updatedOrder.Customer.Name,
                Pizza = updatedOrder.Pizza.Name,
                OrderedAt = updatedOrder.OrderedAt,
                Price = updatedOrder.Price
            };
            return TypedResults.Ok(responseDto);
        }

        private static async Task<IResult> CreateCustomer(IRepository<Customer> repository, string customerName)
        {
            var customer = new Customer()
            {
                Name = customerName
            };
            await repository.Insert(customer);
            return TypedResults.Created();
        }

        private static async Task<IResult> CreatePizza(IRepository<Pizza> repository, PizzaDto pizzaDto)
        {
            var pizza = new Pizza()
            {
                Name = pizzaDto.Name,
                Price = pizzaDto.Price
            };
            await repository.Insert(pizza);
            return TypedResults.Created();
        }

        private static async Task<IResult> GetPizzaById(IRepository<Pizza> repository, int id)
        {
            var pizza = await repository.GetById(id);
            if (pizza == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(new PizzaDto()
            {
                Name = pizza.Name,
                Price = pizza.Price
            });
        }

        private static async Task<IResult> GetTopping(IRepository<Topping> repository, int id)
        {
            var topping = await repository.GetById(id);
            if (topping == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(new ToppingDto()
            {
                Name = topping.Name,
                Price = topping.Price
            });
        }

        private static async Task<IResult> GetToppings(IRepository<Topping> repository)
        {
            var toppings = await repository.Get();
            return TypedResults.Ok(toppings.Select(t => new ToppingDto()
            {
                Name = t.Name,
                Price = t.Price
            }));
        }

        private static async Task<IResult> DeliverOrder(IRepository<Order> repository, int id)
        {
            var order = await repository.GetById(id);
            if (order == null)
            {
                return TypedResults.NotFound();
            }
            order.IsDelivered = true;
            await repository.Update(order);
            return TypedResults.Ok("Order has been delivered");
        }

        private static async Task<IResult> GetOrdersByDriverId(IRepository<Order> repository, int driverId)
        {
            var orders = await repository.GetWithIncludes(o => o.Customer, o => o.Pizza, o => o.DeliveryDriver);
            return TypedResults.Ok(orders.Where(o => o.DeliveryDriverId == driverId).Select(o => new OrderDto()
            {
                Customer = o.Customer.Name,
                Pizza = o.Pizza.Name,
                OrderedAt = o.OrderedAt,
                Price = o.Price,
                Stage = o.OrderedAt.GetPizzaStage().GetPizzaStageString(),
                EstimatedDelivery = DeliveryEngine.GetEstimatedDeliveryInMinutes(orders, o.Id)
            }));
        }

        private static async Task<IResult> AssignOrderToDriver(IRepository<Order> repository, int orderId, int driverId)
        {
            var order = await repository.GetById(orderId);
            if (order == null)
            {
                return TypedResults.NotFound();
            }
            order.DeliveryDriverId = driverId;
            await repository.Update(order);
            return TypedResults.Ok("Order has been assigned to driver");
        }
    }
}
