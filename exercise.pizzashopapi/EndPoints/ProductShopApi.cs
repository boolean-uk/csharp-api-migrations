using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Models;
using exercise.pizzashopapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.pizzashopapi.EndPoints
{
    public static class ProductShopApi
    {
        public static void ConfigureProductShopApi(this WebApplication app)
        {
            var restaurant = app.MapGroup("/restaurant");
            restaurant.MapGet("/products", GetProducts);
            restaurant.MapGet("/customers", GetCustomers);
        }

        public static async Task<IResult> GetProducts(IRepository repo)
        {
            IEnumerable<Product>products = await repo.GetProducts();
            return TypedResults.Ok(products);
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
                    Product product = await repo.GetProductById(order.productId);

                    orderDTO.productname = product.Name;
                    orderDTO.productType = product.Type;
                    orderDTO.producttoppings = new List<OTDTO>();

                    if (order.toppings != null)
                    {
                        foreach (OrderToppings toppings in order.toppings.ToList())
                        {
                            Toppings top = await repo.GetToppingsById(toppings.ToppingId);
                            OTDTO OTD = new OTDTO();
                            OTD.name =  top.name;
                            orderDTO.producttoppings.Add(OTD);
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
