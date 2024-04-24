﻿using Microsoft.AspNetCore.Mvc;

using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurants.Application.Restaurants.Dtos;

using MediatR;

namespace Restaurants.API.Controllers
{
    [ApiController]
    [Route("api/restaurants")]
    public class RestaurantsController(IMediator mediator) : ControllerBase
    {
        // Get all restaurants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantDto>>> GetAll()

        {
            var restaurants = await mediator.Send(new GetAllRestaurantsQuery());
            return Ok(restaurants);
        }

        // Get a restaurant by id
        [HttpGet("{id}")]
        //[Route("{id}")] && [HttpGet] are equal to [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantDto?>> GetById([FromRoute] int id)
        {
            var restaurant = await mediator.Send(new GetRestaurantByIdQuery(id));

            return Ok(restaurant);
        }

        // Update a restaurant by id
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateRestaurant([FromRoute] int id, UpdateRestaurantCommand command)
        {
            command.Id = id;
            await mediator.Send(command);
         
            return NoContent();

        }

        // Delete a restaurant by id
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
        {
            await mediator.Send(new DeleteRestaurantCommand(id));

             return NoContent();

        }

        // Post to create a new restaurant
        [HttpPost]
        public async Task<IActionResult> CreateRestaurant(CreateRestaurantCommand command)
        {

            int id = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }


    }
}
