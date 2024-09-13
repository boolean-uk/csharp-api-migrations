using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Models.DTOs;
using exercise.pizzashopapi.Repository;

namespace exercise.pizzashopapi.Service
{
    public class OrderService
    {

        private readonly IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _orderRepository.GetAll(
                o => o.Customer,  
                o => o.Pizza);
        }

        public async Task<Order> GetOrder(int id)
        {
            return await _orderRepository.GetById(id,
                o => o.Customer,
                o => o.Pizza
                );
        }

        public async Task<Order> CreateOrder(Order order)
        {
            var createdOrder = await _orderRepository.Create(order);

            return await GetOrder(order.Id);
        }

        public async Task<Order> UpdateOrder(int id, UpdateOrderDTO order)
        {
            return await _orderRepository.UpdateOrder(id, order);
        }
    }
}
