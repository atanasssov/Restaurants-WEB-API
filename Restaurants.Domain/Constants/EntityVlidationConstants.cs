namespace Restaurants.Domain.Constants
{
    public static class EntityVlidationConstants
    {
        public static class Restaurant
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 120;

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 800;

            public const int CategoryMinLength = 3;
            public const int CategoryMaxLength = 60;

            public const string EmailValidationErrorMessage = "Please provide a valid email address!";

            public const string PhoneValidationErrorMessage = "Please provide a valid email phone number!";

            public const string PostalCodeErrorMessage = "Please provide a valid postal code (XXXX)!)";
        }

        public static class Dish
        {
            public const int NameMaxLength = 100;

            public const int DescriptionMaxLength = 550;
        }
    }
}
