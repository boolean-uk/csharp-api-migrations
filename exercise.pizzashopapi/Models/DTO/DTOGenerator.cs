namespace exercise.pizzashopapi.Models.DTO
{
    public static class DTOGenerator
    {
  
        public static CustomerDTO GetCustomerDTO(Customer c)
        {
            List<OrderDTO> orders = new List<OrderDTO>();

            foreach(Order o in c.Orders)
            {
                orders.Add(GetOrderDTO(o));
            }
            CustomerDTO cDTO = new CustomerDTO()
            {
                Id = c.Id,
                Name = c.Name,
                Orders = orders
            };
            return cDTO;
        }

        public static List<CustomerDTO> GetCustomerDTOs(IEnumerable<Customer> c)
        {
            List<CustomerDTO> cDTOS = new List<CustomerDTO>();
            foreach(Customer customer in c)
            {
                cDTOS.Add(GetCustomerDTO(customer));
            }
            return cDTOS;
        }

        public static OrderDTO GetOrderDTO(Order o)
        {
            double minutes = (DateTime.UtcNow - (o.Pickup.AddMinutes(-15))).TotalMinutes;
            string stage = o.Stage;
            if (o.Stage != "Delivered")
            {
                if (minutes > 2 && minutes <= 15)
                {
                    stage = "In the oven";
                }
                else if (minutes > 15)
                {
                    stage = "Finished";
                }
            }
            
            OrderDTO oDTO = new OrderDTO()
            {
                Id = o.Id,
                Stage = stage,
                Pickup = o.Pickup,
                Customer = new CustomerDTO()
                {
                    Id = o.Customer.Id,
                    Name = o.Customer.Name
                },
                Pizza = new PizzaDTO()
                {
                    Id = o.Pizza.Id,
                    Name = o.Pizza.Name
                }
            };
            return oDTO;
        }

        public static List<OrderDTO> GetOrderDTOs(IEnumerable<Order> orders)
        {
            List<OrderDTO> oDTOs = new List<OrderDTO>();
            foreach(Order o in orders)
            {
                oDTOs.Add(GetOrderDTO(o));
            }
            return oDTOs;
        }
    }
}
