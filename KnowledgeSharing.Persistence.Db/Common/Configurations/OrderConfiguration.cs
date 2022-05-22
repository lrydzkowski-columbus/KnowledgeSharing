using KnowledgeSharing.Persistence.Db.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnowledgeSharing.Persistence.Db.Common.Configurations;

internal class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
{
    public void Configure(EntityTypeBuilder<OrderEntity> builder)
    {
        SetTableName(builder);
        SetPrimaryKey(builder);
        ConfigureRelations(builder);
        ConfigureColumns(builder);
    }

    private void SetTableName(EntityTypeBuilder<OrderEntity> builder)
    {
        builder.ToTable(name: "order", schema: "store");
    }

    private void SetPrimaryKey(EntityTypeBuilder<OrderEntity> builder)
    {
        builder.HasKey(order => order.Id);
    }

    private void ConfigureRelations(EntityTypeBuilder<OrderEntity> builder)
    {
        builder.HasOne(order => order.User)
            .WithMany(user => user.Orders)
            .HasForeignKey(order => order.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    private void ConfigureColumns(EntityTypeBuilder<OrderEntity> builder)
    {
        builder.Property(order => order.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(order => order.UserId)
            .HasColumnName("user_id");

        builder.Property(order => order.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();
    }
}
