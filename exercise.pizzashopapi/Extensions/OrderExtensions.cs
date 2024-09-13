using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Enums;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.ViewModels;

namespace exercise.pizzashopapi.Extensions
{
    public static class OrderExtensions
    {
        private static string GetOrderStatus(OrderStatus status)
        {
            switch (status)
            {
                case OrderStatus.Ordered:
                    return "Ordered";
                case OrderStatus.Preparing:
                    return "Preparing";
                case OrderStatus.Cooking:
                    return "Cooking";
                case OrderStatus.Delivering:
                    return "Delivering";
                case OrderStatus.Delivered:
                    return "Delivered";
                default:
                    return "Unknown Status";
            }
        }
        public static OrderDTO ToOrderDTO(this Order order)
        {
            return new OrderDTO()
            {
                OrderDate = order.OrderDate.ToString("HH:mm"),
                Status = GetOrderStatus(order.Status),
                EstimatedDelivery = order.EstimatedDelivery.ToString("HH:mm"),
                CustomerId = order.CustomerId,
                Customer = order.Customer.Name,
                PizzaId = order.PizzaId,
                Pizza = order.Pizza.Name
            };
        }

        public static Order ToOrder(this OrderPostModel orderPost, Customer customer, Pizza pizza)
        {
            return new Order() 
            { 
                OrderDate = DateTime.UtcNow,
                Customer = customer,
                CustomerId = customer.Id,
                Pizza = pizza,
                PizzaId = pizza.Id 
            };
        }

        public static PizzaOrder ToPizzaOrder(this OrderDTO orderDTO)
        {
            return new PizzaOrder()
            {
                CustomerId = orderDTO.CustomerId,
                PizzaId= orderDTO.PizzaId,
            };
        }
    }
}
