﻿using Microsoft.Extensions.Logging;

using Restaurants.Domain.Repositories;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Entities;

using AutoMapper;
using MediatR;


namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommandHandler (ILogger <UpdateRestaurantCommandHandler> logger,
        IMapper mapper,
        IRestaurantsRepository restaurantsRepository) : IRequestHandler<UpdateRestaurantCommand>
    {
        public async Task  Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Updating restaurant with id: {RestaurantId} with {@UpdatedRestaurant}", request.Id, request);

            var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);
                throw new NotFoundException(nameof(Restaurant), request.Id.ToString());

            mapper.Map(request, restaurant);

            await restaurantsRepository.SaveChanges();

           
        }
    }
}