using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public class Repository : IRepository
    {
        private DataContext _db;
        public async Task<IEnumerable<Order>> GetOrdersByCustomerId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetOrderById(int id)
        { 
            
            throw new NotImplementedException(); 
        
        
        }

        public async Task<List<Order>> GetOrders()
        { 
        
            throw new NotImplementedException();
        
        }


        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            throw new NotImplementedException();
        
        }

        public async Task<Pizza> GetPizzaById(int id)
        { 
            
            throw new NotImplementedException(); 
        
        }


        public async Task<List<Customer>> GetCustomers()
        { 
            throw new NotImplementedException();    
        
        
        }


        public async Task<Customer> GetCustomerById(int id)
        { 
        
            throw new NotImplementedException();
        
        }

    }  

    
       
}
