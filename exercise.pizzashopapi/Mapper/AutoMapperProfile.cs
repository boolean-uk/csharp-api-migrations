using AutoMapper;
using exercise.pizzashopapi.DTO;
using exercise.pizzashopapi.Models;
using System.Numerics;

namespace exercise.pizzashopapi.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
           CreateMap<Pizza, PizzaDTO>();
           CreateMap<Order, OrderDTO>();
           CreateMap<Customer, CustomerDTO>();
           CreateMap<DeliveryDriver, DeliveryDriverDTO>();
           CreateMap<DeliveryDriver, DeliveryDriverWithOrdersDTO>();
        }
    }
}
