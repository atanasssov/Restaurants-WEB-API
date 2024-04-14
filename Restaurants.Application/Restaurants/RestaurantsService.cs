﻿using Microsoft.Extensions.Logging;

using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repositories;
using Restaurants.Domain.Entities;

using AutoMapper;

namespace Restaurants.Application.Restaurants
{
    internal class RestaurantsService(IRestaurantsRepository restaurantsRepository,
                                   ILogger<RestaurantsService> logger,
                                   IMapper mapper) : IRestaurantsService
    {

        public async Task<IEnumerable<RestaurantDto?>> GetAllRestaurants()
        {
            logger.LogInformation("Getting all restaurants");
            var restaurants = await restaurantsRepository.GetAllAsync();

            var restaurantsDtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

            return restaurantsDtos;
        }

        public async Task<RestaurantDto?> GetById(int id)
        {
            logger.LogInformation($"Getting restaurants {id}");
            var restaurant = await restaurantsRepository.GetByIdAsync(id);

            var restaurantDto = mapper.Map<RestaurantDto>(restaurant);

            return restaurantDto;
        }

        public async Task<int> Create(CreateRestaurantDto dto)
        {
            logger.LogInformation("Creating a new restaurant");
            var restaurant = mapper.Map<Restaurant>(dto);

            int id = await restaurantsRepository.Create(restaurant);
            return id;
        }
    }
}
