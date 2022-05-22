using KnowledgeSharing.Persistence.Db.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnowledgeSharing.Persistence.Db.Common.Configurations;

internal class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
{
    public void Configure(EntityTypeBuilder<RoleEntity> builder)
    {
        SetTableName(builder);
        SetPrimaryKey(builder);
        ConfigureColumns(builder);
        InitializeData(builder);
    }

    private void SetTableName(EntityTypeBuilder<RoleEntity> builder)
    {
        builder.ToTable(name: "role", schema: "user");
    }

    private void SetPrimaryKey(EntityTypeBuilder<RoleEntity> builder)
    {
        builder.HasKey(role => role.Id);
    }

    private void ConfigureColumns(EntityTypeBuilder<RoleEntity> builder)
    {
        builder.Property(role => role.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(role => role.Name)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(200);
    }

    private void InitializeData(EntityTypeBuilder<RoleEntity> builder)
    {
        builder.HasData(
            new RoleEntity()
            {
                Id = 1,
                Name = "admin"
            },
            new RoleEntity()
            {
                Id = 2,
                Name = "user"
            }
        );
        builder.Property(role => role.Id).HasIdentityOptions(startValue: 3);
    }
}
