using KnowledgeSharing.Persistence.Db.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnowledgeSharing.Persistence.Db.Common.Configurations;

internal class OrderPositionConfiguration : IEntityTypeConfiguration<OrderPositionEntity>
{
    public void Configure(EntityTypeBuilder<OrderPositionEntity> builder)
    {
        SetTableName(builder);
        SetPrimaryKey(builder);
        ConfigureRelations(builder);
        ConfigureColumns(builder);
    }

    private void SetTableName(EntityTypeBuilder<OrderPositionEntity> builder)
    {
        builder.ToTable(name: "order_position", schema: "store");
    }

    private void SetPrimaryKey(EntityTypeBuilder<OrderPositionEntity> builder)
    {
        builder.HasKey(orderPosition => orderPosition.Id);
    }

    private void ConfigureRelations(EntityTypeBuilder<OrderPositionEntity> builder)
    {
        builder.HasOne(orderPosition => orderPosition.OrderEntity)
            .WithMany(order => order.OrderPositions)
            .HasForeignKey(orderPosition => orderPosition.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    private void ConfigureColumns(EntityTypeBuilder<OrderPositionEntity> builder)
    {
        builder.Property(orderPosition => orderPosition.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(orderPosition => orderPosition.ProductName)
            .HasColumnName("product_name")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(orderPosition => orderPosition.ProductDescription)
            .HasColumnName("product_description")
            .HasMaxLength(2000);

        builder.Property(orderPosition => orderPosition.ProductPrice)
            .HasColumnName("product_price")
            .IsRequired();

        builder.Property(orderPosition => orderPosition.Amount)
            .HasColumnName("amount")
            .IsRequired();

        builder.Property(orderPosition => orderPosition.OrderId)
            .HasColumnName("order_id");
    }
}
