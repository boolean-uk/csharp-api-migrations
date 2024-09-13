namespace exercise.pizzashopapi.DTO
{
    public class ResponseList <T>
    {
        public List<T> returnedItems { get; set; } = new ();
    }
}
