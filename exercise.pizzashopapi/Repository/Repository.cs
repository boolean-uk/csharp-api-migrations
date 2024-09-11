using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace exercise.pizzashopapi.Repository
{
    public class Repository : IRepository
    {
        private DataContext _db;

        public Repository(DataContext db)
        {
            this._db = db;
        }


        //--Orders--
        public async Task<OrderDTO> AddOrder(Order entity)
        {
            //Add it
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();

            //Response
            return ConstructOrderDTO(entity);
        }
        public async Task<IEnumerable<OrderDTO>> GetOrders()
        {
            var orders = await _db.Orders.Include(c => c.Customer).Include(p => p.Pizza).ToListAsync();
            List<OrderDTO> result = new List<OrderDTO>();
            foreach (var order in orders)
            {
                result.Add(ConstructOrderDTO(order));
            }

            //Response
            return result;
        }
        public async Task<OrderDTO> GetOrderById(int id)
        {
            //Get order
            var order = await _db.Orders.Include(c => c.Customer).Include(p => p.Pizza).FirstOrDefaultAsync(o => o.Id == id);
            if (order == null)
            {
                throw new Exception("Order not found");
            }

            //Response
            return ConstructOrderDTO(order);
        }
        public async Task<OrderDTO> GetOrderByCustomerId(int id)
        {
            //Get customer
            var customer = await _db.Customers.Include(c => c.Order).Where(c => c.Id == id).FirstOrDefaultAsync();
            if(customer == null)
            {
                throw new Exception("Customer not found");
            }

            //Get the order that corresponds to the customer
            var order = customer.Order;
            if (order == null)
            {
                throw new Exception("Order not found");
            }

            //Response
            return ConstructOrderDTO(order);
        }
        public async Task<OrderDTO> RemoveOrder(int id)
        {
            //Get order
            var order = await _db.Orders.Include(c => c.Customer).Include(p => p.Pizza).Where(o => o.Id == id).FirstOrDefaultAsync();
            if(order == null)
            {
                throw new Exception("Order not found");
            }

            //Remove it
            _db.Orders.Remove(order);
            await _db.SaveChangesAsync();

            //Response
            return ConstructOrderDTO(order);
        }
        private OrderDTO ConstructOrderDTO(Order order)
        {
            return new OrderDTO(order, _db.Customers.ToList(), _db.Pizzas.ToList());
        }



        //--Customers--
        public async Task<CustomerDTO> AddCustomer(Customer entity)
        {
            //Add it
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();

            //Response
            return ConstructCustomerDTO(entity);
        }
        public async Task<IEnumerable<CustomerDTO>> GetCustomers()
        {
            //Get all customers
            var customers = await _db.Customers.ToListAsync();
            List<CustomerDTO> result = new List<CustomerDTO>();
            foreach(var customer in customers)
            {
                result.Add(ConstructCustomerDTO(customer));
            }

            //Response
            return result;
        }
        public async Task<CustomerDTO> GetCustomerById(int id)
        {
            //Get customer
            var customer = await _db.Customers.Where(c => c.Id == id).FirstOrDefaultAsync();
            if(customer == null)
            {
                throw new Exception("Customer not found");
            }

            //Response
            return ConstructCustomerDTO(customer);
        }
        private CustomerDTO ConstructCustomerDTO(Customer customer)
        {
            return new CustomerDTO(customer);
        }



        //--Pizzas--
        public async Task<PizzaDTO> AddPizza(Pizza entity)
        {
            //Add it
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();

            //Response
            return ConstructPizzaDTO(entity);
        }
        public async Task<IEnumerable<PizzaDTO>> GetPizzas()
        {
            //Get all pizzas
            var pizzas = await _db.Pizzas.ToListAsync();
            List<PizzaDTO> result = new List<PizzaDTO>();
            foreach (var pizza in pizzas)
            {
                result.Add(ConstructPizzaDTO(pizza));
            }

            //Response
            return result;
        }
        public async Task<PizzaDTO> GetPizzaById(int id)
        {
            //Get pizza
            var pizza = await _db.Pizzas.Where(p => p.Id == id).FirstOrDefaultAsync();
            if(pizza == null)
            {
                throw new Exception("Pizza not found");
            }

            //Response
            return ConstructPizzaDTO(pizza);
        }
        private PizzaDTO ConstructPizzaDTO(Pizza pizza)
        {
            return new PizzaDTO(pizza);
        }
    }
}
