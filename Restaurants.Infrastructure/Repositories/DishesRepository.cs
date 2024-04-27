using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistance;

namespace Restaurants.Infrastructure.Repositories
{
    internal class DishesRepository (RestaurantsDbContext dbContext): IDishesRepository
    {
        public async Task<int> Create(Dish entity)
        {
            await dbContext.Dishes.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity.Id;
        }
    }
}
