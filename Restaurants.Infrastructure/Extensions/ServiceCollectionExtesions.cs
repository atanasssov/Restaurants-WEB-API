using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Authorization;
using Restaurants.Infrastructure.Authorization.Requirements;
using Restaurants.Infrastructure.Persistance;
using Restaurants.Infrastructure.Repositories;
using Restaurants.Infrastructure.Seeders;

namespace Restaurants.Infrastructure.Extensions
{
    public static class ServiceCollectionExtesions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("RestaurantsDb");
            services.AddDbContext<RestaurantsDbContext>(options =>
            {
                options.UseSqlServer(connectionString)
                .EnableSensitiveDataLogging(); // this method enables  [Parameters=...] in the logging file
            });


            services.AddIdentityApiEndpoints<User>()
                .AddRoles<IdentityRole>()   // identity framework is enabled to support identity roles so that they are included in the user claims
                .AddClaimsPrincipalFactory<RestaurantsUserClaimsPrincipalFactory>()
                .AddEntityFrameworkStores<RestaurantsDbContext>();

            services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
            services.AddScoped<IRestaurantsRepository, RestaurantsRepository>();
            services.AddScoped<IDishesRepository, DishesRepository>();

            // Add policy that allows users with an existing "Nationality" claim to get a certain resource
            //services.AddAuthorizationBuilder()
            //    .AddPolicy("HasNationality", builder => builder.RequireClaim("Nationality"));

            // Add policy that allows users with an existing "Nationality" claim with a value = Polish or German to get a certain resource
            services.AddAuthorizationBuilder()
               .AddPolicy(PolicyNames.HasNationality,
                        builder => builder.RequireClaim(AppClaimTypes.Nationality, "Polish", "German"))
               .AddPolicy(PolicyNames.AtLeast20,
                        builder => builder.AddRequirements(new MinimumAgeRequirement(20)));

            services.AddScoped<IAuthorizationHandler, MinimumAgeRequirementHandler>();
                        

        }
    }
}
