namespace exercise.pizzashopapi.DTO.GetResponse
{
    public class GetPizzaResponse
    {
        public ICollection<PizzaDTO> Pizzas { get; set; } = new List<PizzaDTO>();
    }
}
