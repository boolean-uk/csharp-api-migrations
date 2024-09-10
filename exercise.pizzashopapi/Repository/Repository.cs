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
            throw new NotImplementedException();
        }
        public async Task<OrderDTO> RemoveOrder(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
        public async Task<CustomerDTO> GetCustomerById(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
        public async Task<PizzaDTO> GetPizzaById(int id)
        {
            throw new NotImplementedException();
        }
        private PizzaDTO ConstructPizzaDTO(Pizza pizza)
        {
            return new PizzaDTO(pizza);
        }
    }
}
