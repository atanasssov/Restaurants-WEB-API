using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

using static Restaurants.Domain.Constants.EntityVlidationConstants.Restaurant;

namespace Restaurants.Domain.Entities
{
    [Comment("Restaurant with dishes")]
    public class Restaurants
    {
        [Key]
        [Comment("Restaurant identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Restaurant name")]
        public string Name { get; set; } = default!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("Restaurant description")]
        public string Description { get; set; } = default!;

        [Required]
        [MaxLength(CategoryMaxLength)]
        [Comment("Restaurant category")]
        public string Category { get; set; } = default!;

        [Comment("Is restaurant offering delivery")]
        public bool HasDelivery { get; set; }

        [Comment("Restaurant contact email")]
        [EmailAddress]
        public string? ContactEmail { get; set; }

        [Comment("Restaurant contact number")]
        [Phone]
        public string? ContactNumber { get; set; }

        [Comment("Restaurant address")]
        public Address? Address { get; set; }

        [Comment("Restaurant dishes list")]
        public List<Dish> Dishes { get; set; } = new();
    }
}
