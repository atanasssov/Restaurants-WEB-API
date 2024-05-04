using Microsoft.Extensions.Logging;

using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

using MediatR;
using AutoMapper;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Interfaces;

namespace Restaurants.Application.Dishes.Commands.CreateDish
{
    public class CreateDishCommandHandler (ILogger<CreateDishCommandHandler> logger,
        IRestaurantsRepository restaurantsRepository,
        IMapper mapper,
        IDishesRepository dishesRepository,
        IRestaurantAuthorizationService restaurantAuthorizationService) : IRequestHandler<CreateDishCommand, int>
    {
        public async Task<int> Handle(CreateDishCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating new dish: {@DishRequest}", request);

            var restaurant = await restaurantsRepository.GetByIdAsync(request.RestaurantId);
            
            if (restaurant == null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

            if (!restaurantAuthorizationService.Authorize(restaurant, ResourceOperation.Create))
                throw new ForbidException();

            var dish = mapper.Map<Dish>(request);

           return await dishesRepository.Create(dish);
        }

      
    }
}
