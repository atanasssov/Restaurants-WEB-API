using FluentValidation;

using static Restaurants.Domain.Constants.EntityVlidationConstants.Restaurant;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommandValidator : AbstractValidator<UpdateRestaurantCommand>
    {
        public UpdateRestaurantCommandValidator()
        {
            RuleFor(dto => dto.Name)
                .NotEmpty()
                .Length(NameMinLength, NameMaxLength);

            RuleFor(dto => dto.Description)
                .NotEmpty()
                .Length(DescriptionMinLength, DescriptionMaxLength);
        }
    }
}
