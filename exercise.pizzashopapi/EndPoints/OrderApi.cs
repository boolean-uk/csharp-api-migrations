namespace exercise.pizzashopapi.EndPoints
{
    public static class OrderApi
    {
        public static void ConfigureOrderApi(this WebApplication app)
        {
            var orders = app.MapGroup("orders");
        }
    }
}
