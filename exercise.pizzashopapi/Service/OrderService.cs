using exercise.pizzashopapi.Models;
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
    }
}
