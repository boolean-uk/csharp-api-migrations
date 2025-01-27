using AutoMapper;
using exercise.pizzashopapi.DTO.Request;
using exercise.pizzashopapi.DTO.Response;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            var pizzaShop = app.MapGroup("pizzashop");

            pizzaShop.MapGet("/pizza", GetPizzas);
            pizzaShop.MapGet("/products", GetProducts);
            pizzaShop.MapGet("/toppings", GetToppings);
            pizzaShop.MapGet("/orderByCustomer{id}", GetOrdersByCustomerId);

            pizzaShop.MapPost("/order", AddOrder);
            pizzaShop.MapPost("/orderProduct/{order_id}/{product_id}", AddProductToOrder);
            pizzaShop.MapPost("/orderTopping/{order_id}/{topping_id}", AddToppingToOrder);
        }
        public static async Task<IResult> GetPizzas(IRepository<Pizza> repository)
        {
            var pizzas = await repository.Get();

            return TypedResults.Ok(pizzas);
        }
        public static async Task<IResult> GetProducts(IRepository<Product> repository)
        {
            var products = await repository.Get();

            return TypedResults.Ok(products);
        }
        public static async Task<IResult> GetToppings(IRepository<Topping> repository)
        {
            var toppings = await repository.Get();

            return TypedResults.Ok(toppings);
        }

        public static async Task<IResult> GetOrdersByCustomerId(IRepository<Order> repository, int id, IMapper mapper)
        {
            var orders = await repository.GetOrdersByCustomer(id);

            var orderDTOs = mapper.Map<IEnumerable<OrderDTO>>(orders);

            return TypedResults.Ok(orderDTOs);
        }

        public static async Task<IResult> AddOrder(IRepository<Order> repository, OrderPost model, IMapper mapper)
        {
            Order order = new Order()
            {
                Quantity = model.Quantity,
                PizzaId = model.PizzaId,
                CustomerId = model.CustomerId,
            };
            await repository.Add(order);

            var orderDTOs = mapper.Map<OrderDTO>(order);

            return TypedResults.Created($"https://localhost:7010/orders/{order.Id}", orderDTOs);
        }
        public static async Task<IResult> AddProductToOrder(IRepository<OrderProduct> orderProductRepository,
            IRepository<Order> orderRepository,
            IRepository<Product> productRepository,
            int order_id, int product_id,
            IMapper mapper)
        {
            var order = await orderRepository.GetById(order_id);
            if (order == null)
            {
                return TypedResults.NotFound();
            }

            var product = await productRepository.GetById(product_id);
            if (product == null)
            {
                return TypedResults.NotFound();
            }

            OrderProduct orderProduct = new OrderProduct
            {
                OrderId = order_id,
                ProductId = product_id,
                Order = order,
                Product = product,
            };


            await orderProductRepository.Add(orderProduct);

            order.Products.Add(orderProduct);

            await orderRepository.Update(order);

            var orderDTOs = mapper.Map<OrderDTO>(order);

            return TypedResults.Created($"https://localhost:7010/orders/{order.Id}", orderDTOs);
        }
        public static async Task<IResult> AddToppingToOrder(IRepository<OrderTopping> toppingProductRepository,
            IRepository<Order> orderRepository,
            IRepository<Topping> toppingRepository,
            int order_id, int topping_id,
            IMapper mapper)
        {
            var order = await orderRepository.GetById(order_id);
            if (order == null)
            {
                return TypedResults.NotFound();
            }

            var topping = await toppingRepository.GetById(topping_id);
            if (topping == null)
            {
                return TypedResults.NotFound();
            }

            OrderTopping orderTopping = new OrderTopping
            {
                OrderId = order_id,
                ToppingId = topping_id,
                Order = order,
                Topping = topping,
            };


            await toppingProductRepository.Add(orderTopping);

            order.Toppings.Add(orderTopping);

            await orderRepository.Update(order);

            var orderDTOs = mapper.Map<OrderDTO>(order);

            return TypedResults.Created($"https://localhost:7010/orders/{order.Id}", orderDTOs);
        }
    }
}
