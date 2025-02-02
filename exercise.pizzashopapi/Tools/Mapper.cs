using AutoMapper;
using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Models;
using System;
using System.Collections.Generic;

namespace exercise.pizzashopapi.Tools
{
    public class Mapper : Profile
    {
        private static readonly Random Random = new Random();
        private static readonly List<string> OrderStatuses = new List<string>
        {
            "Preparing", "Baking", "Quality Check", "Out for Delivery", "Delivered"
        };

        public Mapper()
        {
            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
                .ForMember(dest => dest.Pizza, opt => opt.MapFrom(src => src.Pizza))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.PizzaId, opt => opt.MapFrom(src => src.PizzaId))
                .ForMember(dest => dest.OrderStatus, opt => opt.MapFrom(src => src.OrderStatus ?? "Pending"));

            CreateMap<OrderDTO, Order>()
                .ForMember(dest => dest.OrderStatus, opt => opt.MapFrom(src => OrderStatuses[Random.Next(OrderStatuses.Count)]));

            CreateMap<OrderTopping, OrderToppingDTO>().ReverseMap();
            CreateMap<Toppings, ToppingDTO>().ReverseMap();
            CreateMap<Toppings, AddToppingDTO>().ReverseMap();
            CreateMap<Order, AddOrderDTO>().ReverseMap();
            CreateMap<Customer, CustomerNoListOrderDTO>().ReverseMap();
            CreateMap<Pizza, PizzaNoListOrderDTO>().ReverseMap();
            CreateMap<Pizza, PizzaDTO>().ReverseMap();
        }
    }
}
