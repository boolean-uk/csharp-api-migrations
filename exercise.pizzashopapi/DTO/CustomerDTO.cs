namespace exercise.pizzashopapi.DTO
{
    public class CustomerDTO
    {
        public record CreateCustomerDTO(string customerFullName)
        {

        }
        public record GetCustomerDTO(string CustomerFullName)
        {

        }
    }
}
