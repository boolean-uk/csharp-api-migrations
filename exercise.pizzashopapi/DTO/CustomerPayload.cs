namespace exercise.pizzashopapi.DTO
{
    public class CustomerPayload
    {
        public string Name { get; set; }
        public CustomerPayload(string name)
        {
            Name = name;
        }
    }
}
