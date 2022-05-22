﻿// <auto-generated />
using System;
using KnowledgeSharing.Persistence.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KnowledgeSharing.Persistence.EFCoreFluentAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220511074325_remove-test-table")]
    partial class removetesttable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("category_product", b =>
                {
                    b.Property<int>("category_id")
                        .HasColumnType("integer");

                    b.Property<int>("product_id")
                        .HasColumnType("integer");

                    b.HasKey("category_id", "product_id");

                    b.HasIndex("product_id");

                    b.ToTable("category_product", "store");
                });

            modelBuilder.Entity("KnowledgeSharing.Persistence.EFCoreFluentAPI.Common.Entities.CategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("name");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("parent_category_id");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("category", "store");
                });

            modelBuilder.Entity("KnowledgeSharing.Persistence.EFCoreFluentAPI.Common.Entities.OrderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("order", "store");
                });

            modelBuilder.Entity("KnowledgeSharing.Persistence.EFCoreFluentAPI.Common.Entities.OrderPositionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("integer")
                        .HasColumnName("amount");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer")
                        .HasColumnName("order_id");

                    b.Property<string>("ProductDescription")
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasColumnName("product_description");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("product_name");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("numeric")
                        .HasColumnName("product_price");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("order_position", "store");
                });

            modelBuilder.Entity("KnowledgeSharing.Persistence.EFCoreFluentAPI.Common.Entities.ProductEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.HasKey("Id");

                    b.ToTable("product", "store");
                });

            modelBuilder.Entity("KnowledgeSharing.Persistence.EFCoreFluentAPI.Common.Entities.RoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<int>("Id"), 3L, null, null, null, null, null);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("role", "user");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "user"
                        });
                });

            modelBuilder.Entity("KnowledgeSharing.Persistence.EFCoreFluentAPI.Common.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<int>("Id"), 2L, null, null, null, null, null);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("last_name");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("login");

                    b.HasKey("Id");

                    b.ToTable("user", "user");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Łukasz",
                            LastName = "Rydzkowski",
                            Login = "lrydzkowski"
                        });
                });

            modelBuilder.Entity("user_role", b =>
                {
                    b.Property<int>("role_id")
                        .HasColumnType("integer");

                    b.Property<int>("user_id")
                        .HasColumnType("integer");

                    b.HasKey("role_id", "user_id");

                    b.HasIndex("user_id");

                    b.ToTable("user_role", "user");

                    b.HasData(
                        new
                        {
                            role_id = 1,
                            user_id = 1
                        });
                });

            modelBuilder.Entity("category_product", b =>
                {
                    b.HasOne("KnowledgeSharing.Persistence.EFCoreFluentAPI.Common.Entities.CategoryEntity", null)
                        .WithMany()
                        .HasForeignKey("category_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KnowledgeSharing.Persistence.EFCoreFluentAPI.Common.Entities.ProductEntity", null)
                        .WithMany()
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KnowledgeSharing.Persistence.EFCoreFluentAPI.Common.Entities.CategoryEntity", b =>
                {
                    b.HasOne("KnowledgeSharing.Persistence.EFCoreFluentAPI.Common.Entities.CategoryEntity", "ParentCategory")
                        .WithMany("ChildrenCategories")
                        .HasForeignKey("ParentCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("KnowledgeSharing.Persistence.EFCoreFluentAPI.Common.Entities.OrderEntity", b =>
                {
                    b.HasOne("KnowledgeSharing.Persistence.EFCoreFluentAPI.Common.Entities.UserEntity", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("User");
                });

            modelBuilder.Entity("KnowledgeSharing.Persistence.EFCoreFluentAPI.Common.Entities.OrderPositionEntity", b =>
                {
                    b.HasOne("KnowledgeSharing.Persistence.EFCoreFluentAPI.Common.Entities.OrderEntity", "OrderEntity")
                        .WithMany("OrderPositions")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderEntity");
                });

            modelBuilder.Entity("user_role", b =>
                {
                    b.HasOne("KnowledgeSharing.Persistence.EFCoreFluentAPI.Common.Entities.RoleEntity", null)
                        .WithMany()
                        .HasForeignKey("role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KnowledgeSharing.Persistence.EFCoreFluentAPI.Common.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KnowledgeSharing.Persistence.EFCoreFluentAPI.Common.Entities.CategoryEntity", b =>
                {
                    b.Navigation("ChildrenCategories");
                });

            modelBuilder.Entity("KnowledgeSharing.Persistence.EFCoreFluentAPI.Common.Entities.OrderEntity", b =>
                {
                    b.Navigation("OrderPositions");
                });

            modelBuilder.Entity("KnowledgeSharing.Persistence.EFCoreFluentAPI.Common.Entities.UserEntity", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
