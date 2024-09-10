using exercise.pizzashopapi.Models.Order;

namespace exercise.pizzashopapi.Models.Order
{
    public static class OrderMapper
    {
        public static OrderDTO MapToDTO(this Order order)
        {
            return new OrderDTO
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                PizzaId = order.PizzaId
            };
        }

        public static List<OrderDTO> MapListToDTO(this List<Order> order)
        {
            return order.Select(order => new OrderDTO
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                PizzaId = order.PizzaId
            }).ToList();
        }
    }
}
