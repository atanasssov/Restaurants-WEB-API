namespace Restaurants.Domain.Constants
{
    public static class EntityVlidationConstants
    {
        public static class Restaurant
        {
            public const int NameMaxLength = 120;

            public const int DescriptionMaxLength = 800;

            public const int CategoryMaxLength = 60;
        }

        public static class Dish
        {
            public const int NameMaxLength = 100;

            public const int DescriptionMaxLength = 550;
        }
    }
}
