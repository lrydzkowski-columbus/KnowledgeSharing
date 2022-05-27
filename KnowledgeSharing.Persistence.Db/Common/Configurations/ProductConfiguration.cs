using KnowledgeSharing.Persistence.Db.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnowledgeSharing.Persistence.Db.Common.Configurations;

internal class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        SetTableName(builder);
        SetPrimaryKey(builder);
        ConfigureColumns(builder);
    }

    private void SetTableName(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.ToTable(name: "product", schema: "store");
    }

    private void SetPrimaryKey(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.HasKey(product => product.Id);
    }

    private void ConfigureColumns(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.Property(product => product.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(product => product.Name)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(product => product.Description)
            .HasColumnName("description")
            .HasMaxLength(2000);

        builder.Property(product => product.Price)
            .HasColumnName("price");

        builder.Property(product => product.ImageUrl)
            .HasColumnName("image_url");
    }
}
