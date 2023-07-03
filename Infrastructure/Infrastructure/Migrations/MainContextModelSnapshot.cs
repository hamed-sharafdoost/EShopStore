﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(MainContext))]
    partial class MainContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Shoes"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Pants"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "Hats"
                        });
                });

            modelBuilder.Entity("Infrastructure.Comment", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Infrastructure.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Creationtime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Fullprice")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("phonenumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Infrastructure.OrderProduct", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("Infrastructure.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Attributes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CategoryId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<bool>("CommentEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Discount")
                        .HasColumnType("float");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Tag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WarehouseCode")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreatorId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Attributes = "{\"color\":\"red\",\"size\":\"37\"}",
                            CategoryId = 1,
                            CommentEnabled = true,
                            Count = 2,
                            CreationTime = new DateTime(2022, 12, 27, 20, 19, 51, 686, DateTimeKind.Local).AddTicks(1131),
                            CreatorId = 1,
                            Name = "Nike",
                            Price = 232000.0,
                            WarehouseCode = 1
                        },
                        new
                        {
                            ProductId = 2,
                            Attributes = "{\"color\":\"blue\",\"size\":\"33\"}",
                            CategoryId = 2,
                            CommentEnabled = true,
                            Count = 3,
                            CreationTime = new DateTime(2022, 12, 27, 20, 19, 51, 686, DateTimeKind.Local).AddTicks(1150),
                            CreatorId = 2,
                            Name = "Fateh",
                            Price = 456000.0,
                            WarehouseCode = 2
                        });
                });

            modelBuilder.Entity("Infrastructure.ShoppingCart", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("Infrastructure.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SaltText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("int");

                    b.Property<string>("phonenumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("UserRoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Address = "Tehran",
                            CreationTime = new DateTime(2022, 12, 27, 20, 19, 51, 686, DateTimeKind.Local).AddTicks(833),
                            Email = "nt924@gmail.com",
                            Name = "HamedSh",
                            Password = "WhusL4VizP59yctFM31TRNKC9cH71VD5PbkAzc7zLXU=",
                            SaltText = "lIvI9pZxKBKnTeXVLFORnw==",
                            UserRoleId = 1,
                            phonenumber = "09104578701"
                        },
                        new
                        {
                            UserId = 2,
                            Address = "Tehran",
                            CreationTime = new DateTime(2022, 12, 27, 20, 19, 51, 686, DateTimeKind.Local).AddTicks(1034),
                            Email = "hannahGh@gmail.com",
                            Name = "Hanna",
                            Password = "W3jMtIkz2sMGsr69ydlSZRylxIDI+dEZNG7/jHKLH6g=",
                            SaltText = "dncgK2qUxmZFEbfG439Daw==",
                            UserRoleId = 2,
                            phonenumber = "09341837814"
                        },
                        new
                        {
                            UserId = 3,
                            Address = "Tabriz",
                            CreationTime = new DateTime(2022, 12, 27, 20, 19, 51, 686, DateTimeKind.Local).AddTicks(1061),
                            Email = "ahmadbn@gmail.com",
                            Name = "Ahmad",
                            Password = "E8IglkCrXRqLcLrQijgtfcei9U2olZcY1yU3rgZclzg=",
                            SaltText = "xE7eG0alTmA3hdC4eqaldw==",
                            UserRoleId = 3,
                            phonenumber = "091876245612"
                        });
                });

            modelBuilder.Entity("Infrastructure.UserRole", b =>
                {
                    b.Property<int>("UserroleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserroleId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserroleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            UserroleId = 1,
                            Name = "admin"
                        },
                        new
                        {
                            UserroleId = 2,
                            Name = "admin"
                        },
                        new
                        {
                            UserroleId = 3,
                            Name = "customer"
                        });
                });

            modelBuilder.Entity("Infrastructure.Comment", b =>
                {
                    b.HasOne("Infrastructure.Product", "Product")
                        .WithMany("Comments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Infrastructure.Order", b =>
                {
                    b.HasOne("Infrastructure.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Infrastructure.OrderProduct", b =>
                {
                    b.HasOne("Infrastructure.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Infrastructure.Product", b =>
                {
                    b.HasOne("Infrastructure.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("Infrastructure.User", "User")
                        .WithMany("Products")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.ClientNoAction);

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Infrastructure.ShoppingCart", b =>
                {
                    b.HasOne("Infrastructure.Product", "Product")
                        .WithMany("ShoppingCarts")
                        .HasForeignKey("ProductId")
                        .IsRequired();

                    b.HasOne("Infrastructure.User", "User")
                        .WithMany("ShoppingCarts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Infrastructure.User", b =>
                {
                    b.HasOne("Infrastructure.UserRole", "UserRole")
                        .WithMany("Users")
                        .HasForeignKey("UserRoleId")
                        .IsRequired();

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("Infrastructure.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Infrastructure.Order", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("Infrastructure.Product", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("OrderProducts");

                    b.Navigation("ShoppingCarts");
                });

            modelBuilder.Entity("Infrastructure.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Orders");

                    b.Navigation("Products");

                    b.Navigation("ShoppingCarts");
                });

            modelBuilder.Entity("Infrastructure.UserRole", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
