namespace exercise.pizzashopapi.Models
{
    public class Cook
    {
        public event EventHandler UpdateOrder;
        private Queue<PizzaOrder> WaitingToCook { get; } = [];
        private Queue<PizzaOrder> Cooking { get; } = [];
        private int Capacity { get; set; } = 4;


        public PizzaOrder AddToCookingOrder(PizzaOrder pizza)
        {
            Console.WriteLine($"Cook received order for customer {pizza.CustomerId} with pizza {pizza.PizzaId}");
            if (Cooking.Count == Capacity) 
            {
                WaitingToCook.Enqueue(pizza);
                pizza.EstimatedDelivery = EstimatedDelivery();
                return pizza;
            }

            else
            {
                EventArgs args = new EventArgs();
                pizza.StartPreparing();
                pizza.NextEvent += PizzaPrepared;
                pizza.EstimatedDelivery = DateTime.UtcNow.AddMinutes(25); // 15 minutes cooking + 10 minutes delivery
                Cooking.Enqueue(pizza);
                return pizza;
            }
        }

        private DateTime EstimatedDelivery()
        {
            var queueTime = WaitingToCook.Count / 4d;
            var deliveryDate = DateTime.UtcNow.AddMinutes((queueTime * 15) + 15 + 10); // Waiting in queue + 15 minutes cooking + 10 minutes delivery

            var nextPizzaDone = Cooking.Peek().EstimatedDelivery;

            deliveryDate += (nextPizzaDone - DateTime.UtcNow);

            return deliveryDate;
        }

        private void PizzaPrepared(object sender, EventArgs e)
        {
            var pizza = sender as PizzaOrder;
            Console.WriteLine($"Pizza with customer {pizza.CustomerId} with pizza {pizza.PizzaId} finished preparing");
            pizza.NextEvent -= PizzaPrepared;
            pizza.NextEvent += PizzaCooked;
            UpdateOrder?.Invoke(pizza, e);
            pizza.StartCooking();
        }

        private void PizzaCooked(object sender, EventArgs e)
        {
            var pizza = sender as PizzaOrder;
            Console.WriteLine($"Pizza with customer {pizza.CustomerId} with pizza {pizza.PizzaId} finished cooking");
            UpdateOrder?.Invoke(pizza, e); // Update db that pizza is done
            Cooking.Dequeue();

            // This statement replaces a mutex. Mutex is better. This is simpler
            if (WaitingToCook.Count > 0 && Cooking.Count < 4)
            {
                var nextPizza = WaitingToCook.Dequeue();
                Cooking.Enqueue(nextPizza);
                nextPizza.StartPreparing();
                nextPizza.NextEvent += PizzaPrepared;
                Console.WriteLine($"Started cooking Pizza that has customer {pizza.CustomerId} with pizza {pizza.PizzaId}");
                UpdateOrder?.Invoke(nextPizza, e); // Update db that pizza started cooking
            }
        }


    }
}
