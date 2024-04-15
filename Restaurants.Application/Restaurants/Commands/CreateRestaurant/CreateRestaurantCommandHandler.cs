using Microsoft.Extensions.Logging;

using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

using AutoMapper;
using MediatR;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandHandler(ILogger <CreateRestaurantCommandHandler> logger,
         IMapper mapper,
         IRestaurantsRepository restaurantsRepository) : IRequestHandler<CreateRestaurantCommand, int>
    {
        public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating a new restaurant {@Restaurant}", request);
            var restaurant = mapper.Map<Restaurant>(request);

            int id = await restaurantsRepository.Create(restaurant);
            return id;
        }
    }
}
