using KnowledgeSharing.Persistence.Db.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnowledgeSharing.Persistence.Db.Common.Configurations;

internal class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        SetTableName(builder);
        SetPrimaryKey(builder);
        ConfigureRelations(builder);
        ConfigureColumns(builder);
        InitializeData(builder);
    }

    private void SetTableName(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable(name: "user", schema: "user");
    }

    private void SetPrimaryKey(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(user => user.Id);
    }

    private void ConfigureRelations(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasMany(user => user.Roles)
            .WithMany(role => role.Users)
            .UsingEntity<Dictionary<string, object>>(
                "user_role",
                x => x.HasOne<RoleEntity>().WithMany().HasForeignKey("role_id"),
                x => x.HasOne<UserEntity>().WithMany().HasForeignKey("user_id"),
                x => x.ToTable(name: "user_role", schema: "user")
                    .HasData(new Dictionary<string, object>
                    {
                        { "user_id", 1 },
                        { "role_id", 1 }
                    })
            );
    }

    private void ConfigureColumns(EntityTypeBuilder<UserEntity> builder)
    {
        builder.Property(user => user.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(user => user.Login)
            .HasColumnName("login")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(user => user.FirstName)
            .HasColumnName("first_name")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(user => user.LastName)
            .HasColumnName("last_name")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(user => user.Email)
            .HasColumnName("email")
            .HasMaxLength(200);
    }

    private void InitializeData(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasData(
            new UserEntity[]
            {
                    new()
                    {
                        Id = 1,
                        Login = "lrydzkowski",
                        FirstName = "Łukasz",
                        LastName = "Rydzkowski"
                    }
            }
        );
        builder.Property(user => user.Id).HasIdentityOptions(startValue: 2);
    }
}
