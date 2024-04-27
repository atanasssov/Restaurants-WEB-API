using FluentValidation;

using static Restaurants.Domain.Constants.EntityVlidationConstants.Dish;

namespace Restaurants.Application.Dishes.Commands.CreateDish
{
    public class CreateDishCommandValidator : AbstractValidator<CreateDishCommand>
    {
        public CreateDishCommandValidator()
        {
            RuleFor(dish => dish.Name)
               .NotEmpty()
               .Length(NameMinLength, NameMaxLength);

            RuleFor(dish => dish.Description)
               .NotEmpty()
               .Length(DescriptionMinLength, DescriptionMaxLength);

            RuleFor(dish => dish.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Price must be a non-negative number!");

            RuleFor(dish => dish.KiloCalories)
                .GreaterThanOrEqualTo(0)
                .WithMessage("KiloCalories must be a non-negative number!");
        }
    }
}
