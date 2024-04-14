using Restaurants.Domain.Entities;

using AutoMapper;


namespace Restaurants.Application.Dishes
{
    public class DishesProfile : Profile
    {
        public DishesProfile()
        {
            CreateMap<Dish, DishDto>();
        }
    }
}
