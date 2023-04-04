using FoodPool.order.entities;
using FoodPool.user.entities;
using Microsoft.EntityFrameworkCore;

namespace FoodPool.data;

public class FoolpoolDbContext : DbContext
{
    public FoolpoolDbContext(DbContextOptions<FoolpoolDbContext> options) : base(options)
    {
    }

    public DbSet<UserEntity> User => Set<UserEntity>();
    public DbSet<OrderEntity> Order => Set<OrderEntity>();
}