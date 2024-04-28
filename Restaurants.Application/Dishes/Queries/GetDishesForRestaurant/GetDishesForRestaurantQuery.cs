using Restaurants.Application.Dishes.Dtos;

using MediatR;

namespace Restaurants.Application.Dishes.Queries.GetDishesForRestaurant
{
    public class GetDishesForRestaurantQuery (int restaurantId) : IRequest<IEnumerable<DishDto>>
    {
        public int RestaurantId { get; } = restaurantId;
    }
}
