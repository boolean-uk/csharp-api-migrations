using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.DTO;

using Microsoft.EntityFrameworkCore;

namespace exercise.pizzashopapi.Repository
{
    public class Repository : IRepository
    {
        private DataContext _db;
        public Repository(DataContext db)
        {
            _db = db;
        }

        public async Task<CustomerPayload> AddCustomer(CustomerPayload payload)
        {
            Customer customer = new Customer();
            customer.Name = payload.Name;
            _db.Customers.Add(customer);
            await _db.SaveChangesAsync();
            CustomerPayload dto = new CustomerPayload(payload.Name, customer.Id);
            return dto;
        }

        public async Task<OrderPayload> AddOrder(OrderPayload payload)
        {
            Order order = new Order(payload.CustomerId, payload.PizzaId);
            _db.Orders.Add(order);
            await _db.SaveChangesAsync();
            OrderPayload dto = new OrderPayload(payload.CustomerId, payload.PizzaId, payload.Id);
            return dto;
        }

        public async Task<PizzaPayload> AddPizza(PizzaPayload payload)
        {
            Pizza pizza = new Pizza();
            pizza.Name = payload.Name;
            _db.Pizzas.Add(pizza);
            await _db.SaveChangesAsync();
            PizzaPayload dto = new PizzaPayload(payload.Name, payload.Price, pizza.Id);
            return dto;
        }

        public async Task<CustomerPayload> GetCustomer(int id)
        {
            var customer = await _db.Customers.SingleOrDefaultAsync(a => a.Id == id);
            if(customer == null)
            {
                throw new Exception("404, could not find customer!");
            }
            return new CustomerPayload(customer.Name, customer.Id);
        }

        public async Task<IEnumerable<CustomerPayload>> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public async Task<OrderPayload> GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderPayload>> GetOrders()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderPayload>> GetOrdersByCustomerId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PizzaPayload> GetPizza(int id)
        {
            var pizza = await _db.Pizzas.SingleOrDefaultAsync(a => a.Id == id);
            if (pizza == null)
            {
                throw new Exception("404, could not find pizza!");
            }
            return new PizzaPayload(pizza.Name, pizza.Price, pizza.Id);
        }

        public async Task<IEnumerable<PizzaPayload>> GetPizzas()
        {
            throw new NotImplementedException();
        }
    }
}
