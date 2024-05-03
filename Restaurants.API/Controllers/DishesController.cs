using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Restaurants.Application.Dishes.Commands.CreateDish;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Application.Dishes.Queries.GetDishesForRestaurant;
using Restaurants.Application.Dishes.Queries.GetDishByIdForRestaurant;
using Restaurants.Application.Dishes.Commands.DeleteDishesForRestaurant;

using MediatR;
using Restaurants.Infrastructure.Authorization;



namespace Restaurants.API.Controllers
{
    // Post to create a new dish
    [Route("api/restaurants/{restaurantId}/dishes")]
    [ApiController]
    [Authorize]
    public class DishesController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateDish([FromRoute] int restaurantId, CreateDishCommand command)
        {
            command.RestaurantId = restaurantId;
            var dishId = await mediator.Send(command);
            return CreatedAtAction(nameof(GetByIdForRestaurant), new { restaurantId, dishId }, null);
        }

        //  Get all dishes for a restaurant
        [HttpGet]
        [Authorize(Policy = PolicyNames.AtLeast20)]
        public async Task<ActionResult<IEnumerable<DishDto>>> GetAllForRestaurant([FromRoute] int restaurantId)
        {
            var dishes = await mediator.Send(new GetDishesForRestaurantQuery(restaurantId));
            return Ok(dishes);
        }

        // Get a single dish for a restaurant
        [HttpGet("{dishId}")]
        public async Task<ActionResult<DishDto>> GetByIdForRestaurant([FromRoute] int restaurantId, [FromRoute] int dishId)
        {
            var dish = await mediator.Send(new GetDishByIdForRestaurantQuery(restaurantId, dishId));
            return Ok(dish);
        }

        // Delete dishes for a restaurant with id
        [HttpDelete]
        public async Task<IActionResult> DeleteDishesForRestaurant([FromRoute] int restaurantId)
        {
            await mediator.Send(new DeleteDishesForRestaurantCommand(restaurantId));
            return NoContent();
        }
    }

 
}
