using System;
using System.Collections.Generic;
using System.Linq;
using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Utils
{
    public static class DeliveryEngine
    {
        public static DateTime GetEstimatedDelivery(IEnumerable<Order> orders, int id)
        {
            var pendingOrders = orders.Where(order => !order.IsDelivered).ToList();

            var orderIndex = pendingOrders.FindIndex(order => order.Id == id);

            int prepareTime = (orderIndex + 1) * 3;

            int bakeTime = (int)Math.Ceiling((double)(orderIndex + 1) / 4) * 12;

            int deliveryTime = (orderIndex + 1) * 10;

            int totalTime = prepareTime + bakeTime + deliveryTime;

            DateTime result = DateTime.UtcNow.AddMinutes(totalTime);
            return result;
        }

        //get the estimated delivery as minutes from now
        public static int GetEstimatedDeliveryInMinutes(IEnumerable<Order> orders, int id)
        {
            return (int)(GetEstimatedDelivery(orders, id) - DateTime.UtcNow).TotalMinutes;
        }
    }
}
