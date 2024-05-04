using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Application.Common;

using MediatR;


namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants
{
    public class GetAllRestaurantsQuery : IRequest<PagedResult<RestaurantDto>>
    {
        public string? SearchPhrase { get; set; }

        public int PageNumber { get; set; } 

        public int PageSize { get; set; }
    }
}
