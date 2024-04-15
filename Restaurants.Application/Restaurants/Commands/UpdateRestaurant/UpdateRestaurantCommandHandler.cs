﻿using Microsoft.Extensions.Logging;

using Restaurants.Domain.Repositories;

using AutoMapper;
using MediatR;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommandHandler (ILogger <UpdateRestaurantCommandHandler> logger,
        IMapper mapper,
        IRestaurantsRepository restaurantsRepository) : IRequestHandler<UpdateRestaurantCommand, bool>
    {
        public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Updating restaurant with id: {RestaurantId} with {@UpdatedRestaurant}", request.Id, request);

            var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);
            if (restaurant is null)
                return false;

            mapper.Map(request, restaurant);

            await restaurantsRepository.SaveChanges();

            return true;
        }
    }
}
