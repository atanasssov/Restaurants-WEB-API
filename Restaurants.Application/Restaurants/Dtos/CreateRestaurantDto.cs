using System.ComponentModel.DataAnnotations;

using static Restaurants.Domain.Constants.EntityVlidationConstants.Restaurant;

namespace Restaurants.Application.Restaurants.Dtos
{
    public class CreateRestaurantDto
    {
        [Required]
        [StringLength(NameMaxLength,MinimumLength = NameMinLength)]
        public string Name { get; set; } = default!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = default!;

        [Required]
        [StringLength(CategoryMaxLength, MinimumLength = CategoryMinLength)]
        public string Category { get; set; } = default!;
        public bool HasDelivery { get; set; }

        [EmailAddress(ErrorMessage = EmailValidationErrorMessage)]
        public string? ContactEmail { get; set; }

        [Phone(ErrorMessage = PhoneValidationErrorMessage)]
        public string? ContactNumber { get; set; }

        public string? City { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
    }
}
