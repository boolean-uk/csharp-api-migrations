namespace exercise.pizzashopapi.DTO
{
    public class GetResponse<T>()
    {
        public List<T> ResponseItems { get; set; } = new();
    }
}
