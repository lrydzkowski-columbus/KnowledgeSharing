using KnowledgeSharing.Persistence.Db.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnowledgeSharing.Persistence.Db.Common.Configurations;

internal class ProductCommentConfiguration : IEntityTypeConfiguration<ProductCommentEntity>
{
    public void Configure(EntityTypeBuilder<ProductCommentEntity> builder)
    {
        SetTableName(builder);
        SetPrimaryKey(builder);
        ConfigureRelations(builder);
        ConfigureColumns(builder);
    }

    private void SetTableName(EntityTypeBuilder<ProductCommentEntity> builder)
    {
        builder.ToTable(name: "product_comment", schema: "store");
    }

    private void SetPrimaryKey(EntityTypeBuilder<ProductCommentEntity> builder)
    {
        builder.HasKey(productComment => productComment.Id);
    }

    private void ConfigureRelations(EntityTypeBuilder<ProductCommentEntity> builder)
    {
        builder.HasOne(productComment => productComment.Product)
            .WithMany(product => product.Comments)
            .HasForeignKey(productComment => productComment.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    private void ConfigureColumns(EntityTypeBuilder<ProductCommentEntity> builder)
    {
        builder.Property(productComment => productComment.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(productComment => productComment.Comment)
            .HasColumnName("comment")
            .IsRequired()
            .HasMaxLength(4000);

        builder.Property(productComment => productComment.ProductId)
            .HasColumnName("product_id");
    }
}
