using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository
    {
        //IEnumerable<Order> GetOrdersByCustomer();
        Task<IEnumerable<Order>> GetOrders();
        Task<string> GetCustomerNameById(int id);
        Task<string> GetPizzaNameById(int id);
        Task<decimal> GetPizzaPriceById(int id);


    }
}
