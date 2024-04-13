
using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

using static Restaurants.Domain.Constants.EntityVlidationConstants.Restaurant;

namespace Restaurants.Domain.Entities
{
    [Comment("Dish to order")]
    public class Dish
    {
        [Key]
        [Comment("Restaurant identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Dish name")]
        public string Name { get; set; } = default!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("Dish description")]
        public string Description { get; set; } = default!;

        [Required]
        [Comment("Dish price")]
        public decimal Price { get; set; }

        [Comment("Dish price")]
        public int? KiloCalories { get; set; }

        [Comment("Restaurant identifier")]
        public int RestaurantId { get; set; }
    }
}