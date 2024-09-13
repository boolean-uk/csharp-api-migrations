using exercise.pizzashopapi.Data;
using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Extensions;
using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Services
{
    public class OrderCookManager
    {
        private Cook _cook;

        public OrderCookManager(Cook cook)
        {
            _cook = cook;
            _cook.UpdateOrder += UpdateOrder;
        }

        public PizzaOrder StartCooking(OrderDTO order)
        {
            var pizzaOrder = _cook.AddToCookingOrder(order.ToPizzaOrder());
            
            return pizzaOrder;
        }

        public async void UpdateOrder(object sender, EventArgs e)
        {
            DataContext _db = new DataContext();
            PizzaOrder pizzaOrder = (PizzaOrder)sender;

            var order = await _db.Orders.FindAsync(pizzaOrder.PizzaId, pizzaOrder.CustomerId);

            order.Status = pizzaOrder.Status;
            order.EstimatedDelivery = pizzaOrder.EstimatedDelivery;

            _db.Orders.Update(order);

            await _db.SaveChangesAsync();
        }
    }
}
