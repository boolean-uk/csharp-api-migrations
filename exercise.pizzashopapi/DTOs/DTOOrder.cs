namespace exercise.pizzashopapi.DTOs
{
    public class DTOOrder
    { 
        public string DeliveryAdcress { get; set; }
        public DTOCustomer Customer { get; set; }
        public DTOPizza Pizza { get; set; }

    }
}
