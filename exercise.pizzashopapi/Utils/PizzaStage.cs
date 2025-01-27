using System;

namespace exercise.pizzashopapi.Utils
{
    public enum PizzaStage
    {
        Preparing,
        Baking,
        Delivering,
        Delivered
    }
    public static class PizzaStageCalculor
    {
        public static PizzaStage GetPizzaStage(this DateTime orderTime)
        {
            var elapsed = DateTime.UtcNow - orderTime;

            if (elapsed.TotalMinutes < 3)
            {
                return PizzaStage.Preparing;
            }
            else if (elapsed.TotalMinutes < 15)
            {
                return PizzaStage.Baking;
            }
            else if (elapsed.TotalMinutes < 25)
            {
                return PizzaStage.Delivering;
            }
            else
            {
                return PizzaStage.Delivered;
            }
        }

        public static string GetPizzaStageString(this PizzaStage stage)
        {
            switch (stage)
            {
                case PizzaStage.Preparing:
                    return "Preparing";
                case PizzaStage.Baking:
                    return "Baking";
                case PizzaStage.Delivering:
                    return "Delivering";
                case PizzaStage.Delivered:
                    return "Delivered";
                default:
                    return "Lost, ops..";
            }
        }
    }
}
