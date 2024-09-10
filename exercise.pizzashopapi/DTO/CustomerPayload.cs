namespace exercise.pizzashopapi.DTO
{
    public class CustomerPayload
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public CustomerPayload(string name, int id)
        {
            Name = name;
            Id = id;
        }
    }
}
