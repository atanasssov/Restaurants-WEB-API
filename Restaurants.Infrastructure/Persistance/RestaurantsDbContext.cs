using Microsoft.EntityFrameworkCore;

using Restaurants.Domain.Entities;

namespace Restaurants.Infrastructure.Persistance
{
    // using primary constructor
    internal class RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> options) : DbContext(options)
    {

        // old constructor
        //public RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> options) : base(options)
        //{

        //}
        internal DbSet<Restaurant> Restaurants {get;set;}

        internal DbSet<Dish> Dishes { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Address table won't be seeded in the database 
            modelBuilder.Entity<Restaurant>()
                .OwnsOne(r => r.Address);

            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.Dishes)
                .WithOne()
                .HasForeignKey(d => d.RestaurantId);
        }
    }
}
