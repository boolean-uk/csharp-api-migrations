namespace exercise.pizzashopapi.Models
{
    public static class Cook
    {
        private static Queue<PizzaOrder> WaitingToCook = [];
        private static Queue<PizzaOrder> Cooking = [];
        private static int Capacity = 4;

        public static void AddToCookingOrder(PizzaOrder pizza)
        {
            if (Cooking.Count == Capacity) WaitingToCook.Enqueue(pizza);

            else 
            {
                pizza.StartPreparing();
                pizza.NextEvent += PizzaPrepared;
                pizza.EstimatedFinish = DateTime.UtcNow.AddMinutes(15);
                Cooking.Enqueue(pizza);
                Capacity += 1;
            }
        }

        private static void PizzaPrepared(object sender, EventArgs e)
        {
            var pizza = sender as PizzaOrder;
            Console.WriteLine($"Pizza {pizza.OrderId} finished preparing");
            pizza.NextEvent -= PizzaPrepared;
            pizza.NextEvent += PizzaCooked;
        }

        private static void PizzaCooked(object sender, EventArgs e)
        {
            var pizza = sender as PizzaOrder;
            Console.WriteLine($"Pizza {pizza.OrderId} finished cooking");

            if(WaitingToCook.Count > 0 && Cooking.Count < 4)
            {
                var nextPizza = WaitingToCook.Dequeue();
                Cooking.Enqueue(nextPizza);
                nextPizza.StartPreparing();
                nextPizza.NextEvent += PizzaPrepared;
                Console.WriteLine($"Started cooking Pizza {nextPizza.OrderId}");
            }
        }


    }
}
