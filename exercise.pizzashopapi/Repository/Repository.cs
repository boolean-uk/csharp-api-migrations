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
            
            return MakeOrderPayload(order);
        }

        private OrderPayload MakeOrderPayload(Order order)
        {
            var customer =  _db.Customers.SingleOrDefault(a => a.Id == order.CustomerId);
            if (customer == null)
            {
                throw new Exception("404, could not find customer!");
            }

            var pizza =  _db.Pizzas.SingleOrDefault(a => a.Id == order.PizzaId);
            if (pizza == null)
            {
                throw new Exception("404, could not find pizza!");
            }

            OrderPayload dto = new OrderPayload(customer.Name, pizza.Name, pizza.Price, order.Status);
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
            UpdateOrder(order);
            var pizza = await _db.Pizzas.SingleOrDefaultAsync(a => a.Id == order.PizzaId);
            var customer = await _db.Customers.SingleOrDefaultAsync(a => a.Id == order.CustomerId);
            if(pizza == null || customer == null)
            {
                throw new Exception("404, could not find customer/pizza!");

            }
            await _db.SaveChangesAsync();

            return MakeOrderPayload(order);
        }

        public async Task<IEnumerable<OrderPayload>> GetOrders()
        {
            var order = await _db.Orders.ToListAsync();
            List<OrderPayload> orders = new List<OrderPayload>();
            foreach (var o in order)
            {
                UpdateOrder(o);
                var pizza = await _db.Pizzas.SingleOrDefaultAsync(a => a.Id == o.PizzaId);
                var customer = await _db.Customers.SingleOrDefaultAsync(a => a.Id == o.CustomerId);
                if (pizza == null || customer == null)
                {
                    throw new Exception("404, could not find customer/pizza!");

                }
                orders.Add(MakeOrderPayload(o));
                
            }
            await _db.SaveChangesAsync();
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
                    UpdateOrder(o);
                    var pizza = await _db.Pizzas.SingleOrDefaultAsync(a => a.Id == o.PizzaId);
                    var customer = await _db.Customers.SingleOrDefaultAsync(a => a.Id == o.CustomerId);
                    if (pizza == null || customer == null)
                    {
                        throw new Exception("404, could not find customer/pizza!");

                    }
                    orders.Add(MakeOrderPayload(o));
                }
            }
            await _db.SaveChangesAsync();

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
        private void UpdateOrder(Order order)
        {
            order.TimeSinceOrdered = DateTime.Now.ToUniversalTime().Subtract(order.TimeOrdered).Duration().TotalMinutes;

           
            if (order.TimeSinceOrdered >= 3 && order.Status == "Preparing pizza")
            {
                order.Status = "Cooking in the oven";
            }
            
            
            if (order.TimeSinceOrdered >= 15 && order.Status == "Cooking in the oven") //3+12
            {
                order.Status = "Out for delivery";
            }
            

        }

        public async Task<OrderPayload> MarkOrderAsAsDelivered(int orderId)
        {
            var order = await _db.Orders.SingleOrDefaultAsync(a => a.Id == orderId);
            if (order == null)
            {
                throw new Exception("404, could not find order!");
            }
            UpdateOrder(order);
            
            if(order.Status == "Out for delivery")
            {
                order.Status = "Delivered";
            }

            await _db.SaveChangesAsync();

            return MakeOrderPayload(order);
        }
    }
}
