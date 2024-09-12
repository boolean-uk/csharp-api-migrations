using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Models.DTOs;
using exercise.pizzashopapi.Repository;

namespace exercise.pizzashopapi.Service
{
    public class CustomerService
    {

        private readonly IRepository<Customer> _customerRepository;

        public CustomerService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _customerRepository.GetCustomers();
        }

        public async Task<Customer> GetCustomer(int id)
        {
            return await _customerRepository.GetCustomer(id);
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            var createdCustomer = await _customerRepository.Create(customer);

            return createdCustomer;
        }
    }
}
