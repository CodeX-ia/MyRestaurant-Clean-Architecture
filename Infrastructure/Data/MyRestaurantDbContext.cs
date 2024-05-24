using Microsoft.EntityFrameworkCore;
using MyRestaurant.Domain.Entities;
using MyRestaurant.Infrastructure.Data.Configurations;

namespace MyRestaurant.Infrastructure.Data;

public class MyRestaurantDbContext : DbContext
{
    public MyRestaurantDbContext(DbContextOptions<MyRestaurantDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Menu> Menus { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply individual configurations
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new MenuConfiguration());

        // Alternatively, if you have many configurations, use this:
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyRestaurantDbContext).Assembly);
    }
}
