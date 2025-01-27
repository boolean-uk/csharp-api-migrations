using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Models.DTO;
using exercise.pizzashopapi.Repository;
using exercise.pizzashopapi.Repository.GenericRepositories;
using exercise.pizzashopapi.Repository.SpecificRepositories;
using Microsoft.AspNetCore.Mvc;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            var api = app.MapGroup("/api");

            var orders = api.MapGroup("/orders");
            orders.MapGet("/", GetOrders);
            orders.MapGet("/customer/{customerId}", GetOrdersByCustomer);
            orders.MapPut("/{orderId}/assignDriver/{driverId}", AssignDriverToOrder);
            orders.MapGet("/driver/{driverId}", GetOrdersByDriver);

            var menu = api.MapGroup("/menu");
            menu.MapPost("/addToOrder/{orderId}", AddMenuItemToOrder);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetOrders(IOrderRepository repository)
        {
            var orders = await repository.GetAllOrdersWithDetails();

            var orderDTOs = orders.Select(order => new OrderDTO
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                CustomerName = order.Customer?.Name ?? "Unknown",
                PizzaId = order.PizzaId,
                PizzaName = order.Pizza?.Name ?? "Unknown",
                PizzaPrice = order.Pizza?.Price ?? 0,
                DeliveryDriverId = order.DeliveryDriverId,
                DeliveryDriverName = order.DeliveryDriver?.Name ?? "Not Assigned",
                OrderDate = order.OrderDate,

                // ✅ Include all menu items in the response
                MenuItems = order.OrderMenuItems.Select(omi => new MenuItemDTO
                {
                    Id = omi.MenuItemId,
                    Name = omi.MenuItem?.Name ?? "Unknown",
                    Type = omi.MenuItem?.Type ?? "Unknown",
                    Price = omi.MenuItem?.Price ?? 0,
                    Quantity = omi.Quantity
                }).ToList()

            }).ToList();

            return TypedResults.Ok(orderDTOs);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetOrdersByCustomer(IOrderRepository repository, int customerId)
        {
            var orders = await repository.GetOrdersByCustomer(customerId);
            if (!orders.Any()) return TypedResults.NotFound($"No orders found for customer with ID {customerId}");

            var orderDTOs = orders.Select(order => new OrderDTO
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                CustomerName = order.Customer?.Name ?? "Unknown",
                PizzaId = order.PizzaId,
                PizzaName = order.Pizza?.Name ?? "Unknown",
                PizzaPrice = order.Pizza?.Price ?? 0,
                DeliveryDriverId = order.DeliveryDriverId,
                DeliveryDriverName = order.DeliveryDriver?.Name ?? "Not Assigned",
                OrderDate = order.OrderDate
            }).ToList();

            return TypedResults.Ok(orderDTOs);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> AssignDriverToOrder(IOrderRepository repository, int orderId, int driverId)
        {
            var order = await repository.GetById(orderId);
            if (order == null) return TypedResults.NotFound($"Order with ID {orderId} not found");

            order.DeliveryDriverId = driverId;
            await repository.Update(order);

            // Fetch updated order with details
            var updatedOrder = await repository.GetOrdersByDriver(driverId);
            var orderDTOs = updatedOrder.Select(o => new OrderDTO
            {
                Id = o.Id,
                CustomerId = o.CustomerId,
                CustomerName = o.Customer?.Name ?? "Unknown",
                PizzaId = o.PizzaId,
                PizzaName = o.Pizza?.Name ?? "Unknown",
                PizzaPrice = o.Pizza?.Price ?? 0,
                DeliveryDriverId = o.DeliveryDriverId,
                DeliveryDriverName = o.DeliveryDriver?.Name ?? "Not Assigned",
                OrderDate = o.OrderDate
            }).FirstOrDefault();

            return TypedResults.Ok(orderDTOs);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetOrdersByDriver(IOrderRepository repository, int driverId)
        {
            var orders = await repository.GetOrdersByDriver(driverId);

            if (!orders.Any()) return TypedResults.NotFound($"No orders found for driver with ID {driverId}");

            var orderDTOs = orders.Select(order => new OrderDTO
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                CustomerName = order.Customer?.Name ?? "Unknown",
                PizzaId = order.PizzaId,
                PizzaName = order.Pizza?.Name ?? "Unknown",
                PizzaPrice = order.Pizza?.Price ?? 0,
                DeliveryDriverId = order.DeliveryDriverId,
                DeliveryDriverName = order.DeliveryDriver?.Name ?? "Not Assigned",
                OrderDate = order.OrderDate
            }).ToList();

            return TypedResults.Ok(orderDTOs);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> AddMenuItemToOrder(
            IOrderRepository orderRepository,
            IOrderMenuItemRepository orderMenuItemRepository,
            IRepository<MenuItem> menuRepository,
            int orderId,
            [FromBody] OrderMenuItemRequest request)
        {
            var order = await orderRepository.GetById(orderId);
            if (order == null) return TypedResults.NotFound($"Order with ID {orderId} not found");

            var menuItem = await menuRepository.GetById(request.MenuItemId);
            if (menuItem == null) return TypedResults.BadRequest($"Menu item with ID {request.MenuItemId} does not exist");

            if (request.Quantity < 1) return TypedResults.BadRequest("Quantity must be at least 1.");

            await orderMenuItemRepository.AddMenuItemToOrder(orderId, request.MenuItemId, request.Quantity);

            return TypedResults.Ok($"Item '{menuItem.Name}' (x{request.Quantity}) added to order {orderId}");
        }


    }
}
