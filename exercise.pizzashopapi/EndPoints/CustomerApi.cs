namespace exercise.pizzashopapi.EndPoints
{
    public static class CustomerApi
    {
        public static void ConfigureCustomerApi(this WebApplication app)
        {
            var customers = app.MapGroup("customers");

        }
    }
}
