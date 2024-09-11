﻿using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository
    {
        public Task<IEnumerable<OrderPayload>> GetOrdersByCustomerId(int id);
        public Task<IEnumerable<OrderPayload>> GetOrders();
        public Task<OrderPayload> GetOrderById(int id);
        public Task<IEnumerable<CustomerPayload>> GetCustomers();
        public Task<CustomerPayload> GetCustomer(int id);
        public Task<PizzaPayload> GetPizza(int id);
        public Task<IEnumerable<PizzaPayload>> GetPizzas();
        public Task<PizzaPayload> AddPizza(PizzaPayload payload);
        public Task<OrderPayload> AddOrder(int customerId, int pizzaId);
        public Task<CustomerPayload> AddCustomer(CustomerPayload payload);

        public Task<bool> CheckExists(int type, int id); //0 = customer, 1 = pizza, 2 = order

        public Task<OrderPayload> MarkOrderAsAsDelivered(int orderId);

    }
}
