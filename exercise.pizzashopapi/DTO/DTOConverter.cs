using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.DTO
{
    public static class DTOConverter
    {
        public static DTOPizza DTOPizzaConvert(this Models.Pizza pizza) { return new DTOPizza() { Id = pizza.Id, Name = pizza.Name, Price = pizza.Price }; }

        public static DTOOrder DTOOrderConvert(this Models.Order order) { return new DTOOrder() { CustomerId = order.CustomerId, PizzaId = order.PizzaId }; }

        public static DTOCustomer DTOCustomerConvert(this Models.Customer customer) { return new DTOCustomer() { Id = customer.Id, Name = customer.Name }; }

        public static IEnumerable<DTOPizza> DTOListConvert(this IEnumerable<Pizza> pizzas) 
        {
            return pizzas.Select(p => new DTOPizza { Id = p.Id, Name = p.Name, Price = p.Price }); 
        }

        public static IEnumerable<DTOOrder> DTOListConvert(this IEnumerable<Order> orders)
        {
            return orders.Select(o => new DTOOrder { CustomerId = o.CustomerId, PizzaId = o.PizzaId });
        }

        public static IEnumerable<DTOCustomer> DTOListConvert(this IEnumerable<Customer> customer)
        {
            return customer.Select(c => new DTOCustomer { Id = c.Id, Name = c.Name });
        }

    }
}
