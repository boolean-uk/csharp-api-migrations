using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models.Customer;
using exercise.pizzashopapi.Models.Order;
using exercise.pizzashopapi.Models.Pizza;

namespace exercise.pizzashopapi.Repository
{
    public class Repository : IRepository
    {
        private DataContext _db;

        public Repository(DataContext db)
        {
            _db = db;
        }

        public CustomerDTO BecomeCustomer(string Name)
        {
            Customer customer = null;
            _db.Customers.Add(customer = new Customer { Id = _db.Customers.Max(x => x.Id) ,Name = Name });
            return customer.MapToDTO();
        }

        public List<PizzaDTO> GetMenu()
        {
            return _db.Pizzas.ToList().MapListToDTO();
        }

        public PizzaDTO GetMenuItem(int id)
        {
            var pizza = _db.Pizzas.FirstOrDefault(x => x.Id == id);
            return pizza.MapToDTO();
        }

        public OrderDTO GetOrder(int orderId)
        {
            var order = _db.Orders.FirstOrDefault(x => x.Id == orderId);
            return order.MapToDTO();
        }

        public List<OrderDTO> GetOrders()
        {
            var orders = _db.Orders.ToList();
            return orders.MapListToDTO();
        }

        public List<OrderDTO> GetOrdersByCustomer(int customerId)
        {
            var orders = _db.Orders.Where(x => x.CustomerId == customerId).ToList();
            return orders.MapListToDTO();
        }

        public OrderDTO OrderPizza(int pizzaId, int customerId)
        {
            Order order = null;
            _db.Orders.Add(order = new Order() { Id = _db.Orders.Max(x => x.Id), CustomerId = customerId, PizzaId = pizzaId });
            return order.MapToDTO();
        }

        public OrderDTO UpdateOrder(int orderId, int pizzaId)
        {
            var order = _db.Orders.FirstOrDefault(o => o.Id == orderId);
            if (order != null)
            {
                order.PizzaId = pizzaId;
                _db.SaveChanges();
                return order.MapToDTO();
            }
            return order.MapToDTO();
        }
    }
}
