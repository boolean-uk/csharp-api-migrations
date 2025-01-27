using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {
            var restaurant = app.MapGroup("/restaurant");
            restaurant.MapGet("/pizzas", GetPizzas);
            restaurant.MapGet("/customers", GetCustomers);
        }

        public static async Task<IResult> GetPizzas(IRepository repo)
        {
            IEnumerable<Pizza>pizzas = await repo.GetPizzas();
            return TypedResults.Ok(pizzas);
        }

        public static async Task<IResult> GetCustomers(IRepository repo)
        {

            List<CustomerDTO>DTOList = new List<CustomerDTO> ();

            foreach (Customer customer in await repo.GetCustomers())
            {
                CustomerDTO dto = new CustomerDTO();
                dto.Name = customer.Name;
                dto.Id = customer.Id;
                foreach (Order order in await repo.GetOrdersByCustomer(customer.Id))
                {
                    OrderSimplifiedDTO orderDTO = new OrderSimplifiedDTO();
                    Pizza pizza = await repo.GetPizzaById(order.pizzaId);

                    orderDTO.pizzaname = pizza.Name;
                    orderDTO.pizzatoppings = new List<OTDTO>();

                    if (order.toppings != null)
                    {
                        foreach (OrderToppings toppings in order.toppings.ToList())
                        {
                            Toppings top = await repo.GetToppingsById(toppings.ToppingId);
                            OTDTO OTD = new OTDTO();
                            OTD.name =  top.name;
                            orderDTO.pizzatoppings.Add(OTD);
                        }




                        dto.Orders.Add(orderDTO);
                    }
                }
                    DTOList.Add(dto);
                
            }
            
            

            return TypedResults.Ok(DTOList);
        }
        public static async Task<IResult> GetOrders(IRepository repo)
        {
            IEnumerable<Order> orders = await repo.GetOrders();
            return TypedResults.Ok(orders);
        }

        public static async Task<IResult> GetOrderByCustomer(IRepository repo, int id)
        {
            IEnumerable<Order> orders =  await repo.GetOrdersByCustomer(id);
            return TypedResults.Ok(orders);
        }

    }
}
