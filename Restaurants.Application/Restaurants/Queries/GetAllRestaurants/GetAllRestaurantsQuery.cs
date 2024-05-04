using Restaurants.Application.Restaurants.Dtos;

using MediatR;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants
{
    public class GetAllRestaurantsQuery : IRequest<IEnumerable<RestaurantDto>>
    {
        public string? SearchPhrase { get; set; }
    }
}
