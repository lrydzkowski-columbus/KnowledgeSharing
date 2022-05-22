using KnowledgeSharing.Persistence.Db.Common.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace KnowledgeSharing.Persistence.Db;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<UserEntity> Users => Set<UserEntity>();

    public DbSet<RoleEntity> Roles => Set<RoleEntity>();

    public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();

    public DbSet<ProductEntity> Products => Set<ProductEntity>();

    public DbSet<ProductCommentEntity> ProductComments => Set<ProductCommentEntity>();

    public DbSet<OrderEntity> Orders => Set<OrderEntity>();

    public DbSet<OrderPositionEntity> OrderPositions => Set<OrderPositionEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
