using Microsoft.AspNetCore.Mvc;

using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.API.Controllers
{
    [ApiController]
    [Route("api/restaurants")]
    public class RestaurantsController(IRestaurantsService restaurantsService) : ControllerBase
    {
        // Get all restaurants
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var restaurants = await restaurantsService.GetAllRestaurants();
            return Ok(restaurants);
        }

        // Get a restaurant by id
        [HttpGet("{id}")]
        //[Route("{id}")] && [HttpGet] are equal to [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var restaurant = await restaurantsService.GetById(id);
            if (restaurant is null)
                return NotFound();

            return Ok(restaurant);
        }

        // Post to create a new restaurant
        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantDto createRestaurantDto)
        {
            int id = await restaurantsService.Create(createRestaurantDto);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

    }
}
