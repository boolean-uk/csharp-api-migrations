using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using exercise.pizzashopapi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace exercise.pizzashopapi.EndPoints
{
    public static class PizzaShopApi
    {
        public static void ConfigurePizzaShopApi(this WebApplication app)
        {

            var pizzashop = app.MapGroup("pizzashop");

            pizzashop.MapGet("/pizzas", GetPizzas);
            pizzashop.MapGet("/pizzas{id}", GetPizzaById);
            pizzashop.MapPost("/pizzas", CreatePizza);
            pizzashop.MapGet("/customers", GetCustomers);
            pizzashop.MapGet("/customers{id}", GetCustomerById);
            pizzashop.MapPost("/customers", CreateCustomer);
            //pizzashop.MapGet("/orders", GetOrders);


        }
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPizzas(IRepository repository)
        {
            var pizzas = await repository.GetPizzas();

            return pizzas == null ? TypedResults.NotFound() : TypedResults.Ok(await repository.GetPizzas());

        }
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPizzaById(IRepository repository, int id)
        {
            var pizza = await repository.GetPizzaById(id);

            return pizza == null ? TypedResults.NotFound() : TypedResults.Ok(await repository.GetPizzaById(id));
        }
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreatePizza(IRepository repository, PizzaPostModel model)
        {
            try
            {
                var addedpizza = await repository.CreatePizza(new Pizza() { Name = model.Name, Price = model.Price });
                var target = await repository.GetPizzaById(addedpizza.Id);

                return TypedResults.Ok(target);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetCustomers(IRepository repository)
        {
            var customers = await repository.GetCustomers();
            List<CustomerDTOWithOrders> response = new List<CustomerDTOWithOrders>();
            foreach (Customer customer in customers)
            {
                CustomerDTOWithOrders customerdto = new CustomerDTOWithOrders();
                customerdto.Id = customer.Id;
                customerdto.Name = customer.Name;

                foreach(Order order in customer.Orders)
                {
                    OrderDTO orderdto = new OrderDTO();
                    orderdto.Pizza = order.pizza;
                    customerdto.OrderDTO.Add(orderdto);
                }
                response.Add(customerdto);
            }
            return TypedResults.Ok(response);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetCustomerById(IRepository repository, int id)
        {
            var customer = await repository.GetCustomerById(id);

            if (customer == null) return TypedResults.NotFound();

            CustomerDTOWithOrders customerdto = new CustomerDTOWithOrders()
            {
                Id = customer.Id,
                Name = customer.Name,
            };
            foreach (Order order in customer.Orders)
            {
                OrderDTO orderdto = new OrderDTO();
                orderdto.Pizza = order.pizza;
                customerdto.OrderDTO.Add(orderdto);
            }
            return TypedResults.Ok(customerdto);
        }
        
        public static async Task<IResult> CreateCustomer(IRepository repository, CustomerPostModel model)
        {
            try
            {
                Customer customer = await repository.CreateCustomer(new Customer()
                {
                    Name = model.Name
                });

                var target = await repository.GetCustomerById(customer.Id);

                CustomerDTOwithoutOrder customerdto = new CustomerDTOwithoutOrder()
                {
                    Id = target.Id,
                    Name = target.Name,
                };

                return TypedResults.Ok(customerdto);
            }
            catch(Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }






    }
}

