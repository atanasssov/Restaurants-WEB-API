using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Restaurants.Domain.Entities
{
    public class User : IdentityUser
    {

        public DateOnly? DateOfBirth { get; set; }

        public string? Nationality { get; set; }

        [Comment("List of owned restaurants by user")]
        public List<Restaurant> OwnedRestaurants { get; set; } = [];
    }
}
