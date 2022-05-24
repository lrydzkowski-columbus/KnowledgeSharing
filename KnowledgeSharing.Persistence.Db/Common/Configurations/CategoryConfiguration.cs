using KnowledgeSharing.Persistence.Db.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnowledgeSharing.Persistence.Db.Common.Configurations;

internal class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
{
    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        SetTableName(builder);
        SetPrimaryKey(builder);
        ConfigureRelations(builder);
        ConfigureColumns(builder);
    }

    private void SetTableName(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.ToTable(name: "category", schema: "store");
    }

    private void SetPrimaryKey(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.HasKey(category => category.Id);
    }

    private void ConfigureRelations(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.HasOne(category => category.ParentCategory)
            .WithMany(parent => parent.ChildrenCategories)
            .HasForeignKey(category => category.ParentCategoryId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(category => category.Products)
            .WithMany(product => product.Categories)
            .UsingEntity<Dictionary<string, object>>(
                "category_product",
                x => x.HasOne<ProductEntity>().WithMany().HasForeignKey("product_id"),
                x => x.HasOne<CategoryEntity>().WithMany().HasForeignKey("category_id"),
                x => x.ToTable(name: "category_product", schema: "store")
            );
    }

    private void ConfigureColumns(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.Property(category => category.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(category => category.Name)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(category => category.Description)
            .HasColumnName("description")
            .HasMaxLength(2000);

        builder.Property(category => category.IsVisible)
            .HasColumnName("is_visible");

        builder.Property(category => category.ParentCategoryId)
            .HasColumnName("parent_category_id");
    }
}
