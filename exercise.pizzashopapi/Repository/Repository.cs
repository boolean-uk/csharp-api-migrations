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
            CustomerPayload dto = new CustomerPayload(payload.Name);
            return dto;
        }

        public async Task<OrderPayload> AddOrder(int customerId, int pizzaId)
        {
            Order order = new Order(customerId, pizzaId);
            _db.Orders.Add(order);
            await _db.SaveChangesAsync();
            
            return MakeOrderPayload(customerId, pizzaId);
        }

        private  OrderPayload MakeOrderPayload(int customerId, int pizzaId)
        {
            var customer =  _db.Customers.SingleOrDefault(a => a.Id == customerId);
            if (customer == null)
            {
                throw new Exception("404, could not find customer!");
            }

            var pizza =  _db.Pizzas.SingleOrDefault(a => a.Id == pizzaId);
            if (pizza == null)
            {
                throw new Exception("404, could not find pizza!");
            }

            OrderPayload dto = new OrderPayload(customer.Name, pizza.Name, pizza.Price);
            return dto;
        }

        public async Task<PizzaPayload> AddPizza(PizzaPayload payload)
        {
            Pizza pizza = new Pizza();
            pizza.Name = payload.Name;
            pizza.Price = payload.Price;
            _db.Pizzas.Add(pizza);
            await _db.SaveChangesAsync();
            PizzaPayload dto = new PizzaPayload(payload.Name, payload.Price);
            return dto;
        }

        public async Task<CustomerPayload> GetCustomer(int id)
        {
            var customer = await _db.Customers.SingleOrDefaultAsync(a => a.Id == id);
            if(customer == null)
            {
                throw new Exception("404, could not find customer!");
            }

            return new CustomerPayload(customer.Name);
        }

        public async Task<IEnumerable<CustomerPayload>> GetCustomers()
        {
            var customers = await _db.Customers.ToListAsync();
            List<CustomerPayload> customerPayloads = new List<CustomerPayload>();
            foreach (var customer in customers)
            {
                CustomerPayload dto = new CustomerPayload(customer.Name);
                customerPayloads.Add(dto);
            }
            return customerPayloads;
        }

        public async Task<OrderPayload> GetOrderById(int id)
        {
            var order = await _db.Orders.SingleOrDefaultAsync(a => a.Id == id);
            if(order == null)
            {
                throw new Exception("404, could not find order!");
            }

            var pizza = await _db.Pizzas.SingleOrDefaultAsync(a => a.Id == order.PizzaId);
            var customer = await _db.Customers.SingleOrDefaultAsync(a => a.Id == order.CustomerId);
            if(pizza == null || customer == null)
            {
                throw new Exception("404, could not find customer/pizza!");

            }
            OrderPayload dto = new OrderPayload(customer.Name, pizza.Name, pizza.Price);

            
            return dto;
        }

        public async Task<IEnumerable<OrderPayload>> GetOrders()
        {
            var order = await _db.Orders.ToListAsync();
            List<OrderPayload> orders = new List<OrderPayload>();
            foreach (var o in order)
            {
                var pizza = await _db.Pizzas.SingleOrDefaultAsync(a => a.Id == o.PizzaId);
                var customer = await _db.Customers.SingleOrDefaultAsync(a => a.Id == o.CustomerId);
                if (pizza == null || customer == null)
                {
                    throw new Exception("404, could not find customer/pizza!");

                }
                OrderPayload dto = new OrderPayload(customer.Name, pizza.Name, pizza.Price);
                orders.Add(dto);
                
            }
            return orders;
        }

        public async Task<IEnumerable<OrderPayload>> GetOrdersByCustomerId(int id)
        {
            var order = await _db.Orders.ToListAsync();
            List<OrderPayload> orders = new List<OrderPayload>();
            foreach (var o in order)
            {
                if(o.CustomerId == id)
                {
                    var pizza = await _db.Pizzas.SingleOrDefaultAsync(a => a.Id == o.PizzaId);
                    var customer = await _db.Customers.SingleOrDefaultAsync(a => a.Id == o.CustomerId);
                    if (pizza == null || customer == null)
                    {
                        throw new Exception("404, could not find customer/pizza!");

                    }
                    OrderPayload dto = new OrderPayload(customer.Name, pizza.Name, pizza.Price);
                    orders.Add(dto);
                }
            }
            return orders;
        }

        public async Task<PizzaPayload> GetPizza(int id)
        {
            var pizza = await _db.Pizzas.SingleOrDefaultAsync(a => a.Id == id);
            if (pizza == null)
            {
                throw new Exception("404, could not find pizza!");
            }
            return new PizzaPayload(pizza.Name, pizza.Price);
        }

        public async Task<IEnumerable<PizzaPayload>> GetPizzas()
        {
            var pizzas = await _db.Pizzas.ToListAsync();
            List<PizzaPayload> pizzaPayloads = new List<PizzaPayload>();
            foreach (var pizza in pizzas)
            {
                PizzaPayload dto = new PizzaPayload(pizza.Name, pizza.Price);
                pizzaPayloads.Add(dto);
            }
            return pizzaPayloads;
        }

        public async Task<bool> CheckExists(int type, int id)
        {
            if(type == 0) // customer
            {
                var customer = await _db.Customers.SingleOrDefaultAsync(a => a.Id == id);
                if (customer != null)
                {
                    return true;
                }
            }
            else if(type == 1) //pizza
            {
                var pizza = await _db.Pizzas.SingleOrDefaultAsync(a => a.Id == id);
                if (pizza != null)
                {
                    return true;
                }
            }
            else if(type == 2) // order
            {
                var order = await _db.Orders.SingleOrDefaultAsync(a => a.Id == id);
                if (order != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
