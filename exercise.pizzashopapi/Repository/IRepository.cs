﻿using exercise.pizzashopapi.Models;

namespace exercise.pizzashopapi.Repository
{
    public interface IRepository
    {
        IEnumerable<Order> GetOrders();
    }
}