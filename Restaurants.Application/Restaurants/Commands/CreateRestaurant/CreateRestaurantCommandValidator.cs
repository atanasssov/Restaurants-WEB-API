using FluentValidation;

using static Restaurants.Domain.Constants.EntityVlidationConstants.Restaurant;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
    {
        public CreateRestaurantCommandValidator()
        {
            RuleFor(dto => dto.Name)
                .NotEmpty()
                .Length(NameMinLength, NameMaxLength);

            RuleFor(dto => dto.Description)
                .NotEmpty()
                .Length(DescriptionMinLength, DescriptionMaxLength);

            RuleFor(dto => dto.Category)
                .NotEmpty()
                .Length(CategoryMinLength, CategoryMaxLength);

            // Email Address() methods makes the email address required to it is removed because in this case email address is not reqired for creating a restaurant
            //RuleFor(dto => dto.ContactEmail)
            //  .EmailAddress()
            //  .WithMessage(EmailValidationErrorMessage);

            // applies a regular expression pattern to validate the phone number. This pattern allows for an optional leading +, followed by one digit between 1 and 9, and then 5 to 14 digits. 
            RuleFor(dto => dto.ContactNumber)
                .Matches(@"^\+?[1-9]\d{5,14}$")
                 .When(dto => dto.ContactEmail != null)
                 .WithMessage(PhoneValidationErrorMessage)
                 .When(dto => !string.IsNullOrEmpty(dto.ContactNumber));
              

            // regex for 4 number codes only  - ex: [9300]
            RuleFor(dto => dto.PostalCode)
               .Matches(@"^\d{4}$")
               .When(dto => !string.IsNullOrEmpty(dto.ContactNumber))
               // the rule applies only if not null
               .WithMessage(PostalCodeErrorMessage);


        }
    }
}
