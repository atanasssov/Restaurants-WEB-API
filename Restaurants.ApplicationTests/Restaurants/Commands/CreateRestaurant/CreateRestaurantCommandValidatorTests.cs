using FluentValidation.TestHelper;
using Xunit;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant.Tests
{
    public class CreateRestaurantCommandValidatorTests
    {
        [Fact()]
        public void Validator_ForValidCommand_ShouldNotHaveValidationErrors()
        {
            // arrange

            var command = new CreateRestaurantCommand()
            {
                Name = "Test",
                Description = "Here is some test description just for the test!",
                Category = "Italian",
                ContactEmail = "test@test.com",
                PostalCode = "1225",
            };

            var validator = new CreateRestaurantCommandValidator();

            // act

            var result = validator.TestValidate(command);

            // assert

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact()]
        public void Validator_ForInvalidCommand_ShouldHaveValidationErrors()
        {
            // arrange

            var command = new CreateRestaurantCommand()
            {
                Name = "Te",
                Category = "Ia",
                Description = "Here is..",
                PostalCode = "11111",
                ContactNumber = "111"

            };

            var validator = new CreateRestaurantCommandValidator();

            // act

            var result = validator.TestValidate(command);

            // assert

            result.ShouldHaveValidationErrorFor(c => c.Name);
            result.ShouldHaveValidationErrorFor(c => c.Category);
            result.ShouldHaveValidationErrorFor(c => c.Description);
            result.ShouldHaveValidationErrorFor(c => c.PostalCode);
            result.ShouldHaveValidationErrorFor(c => c.ContactNumber);

        }

        [Theory()]
        [InlineData("1")]
        [InlineData("25")]
        [InlineData("103")]
        [InlineData("44901")]
        [InlineData("a213")]
        [InlineData("a1Aa")]
        [InlineData("21-33")]
        public void Validator_ForInvalidPostalCode_ShouldHaveValidationErrorsForPostalCodeProperty(string postalCode)
        {
            // arrange
            var validator = new CreateRestaurantCommandValidator();
            var command = new CreateRestaurantCommand { PostalCode = postalCode };

            // act

            var result = validator.TestValidate(command);

            // assert
            result.ShouldHaveValidationErrorFor(c => c.PostalCode);
        }
    }
}