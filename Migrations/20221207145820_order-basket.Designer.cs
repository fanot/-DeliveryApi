﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Helpers;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221207145820_order-basket")]
    partial class orderbasket
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DishUsers", b =>
                {
                    b.Property<string>("DishId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UsersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DishId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("DishUsers");
                });

            modelBuilder.Entity("WebApi.Entities.Cart", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("DishId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OrdersId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double?>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<string>("UsersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("DishId");

                    b.HasIndex("OrdersId");

                    b.HasIndex("UsersId");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("WebApi.Entities.Dish", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double?>("Rating")
                        .HasColumnType("float");

                    b.Property<bool>("Vegetarian")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Dish");
                });

            modelBuilder.Entity("WebApi.Entities.Order", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeliveryTime")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("DishId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("OrderTime")
                        .HasColumnType("datetime2");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UsersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("DishId");

                    b.HasIndex("UsersId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("WebApi.Entities.Users", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DishUsers", b =>
                {
                    b.HasOne("WebApi.Entities.Dish", null)
                        .WithMany()
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.Entities.Users", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApi.Entities.Cart", b =>
                {
                    b.HasOne("WebApi.Entities.Dish", "Dish")
                        .WithMany("Carts")
                        .HasForeignKey("DishId");

                    b.HasOne("WebApi.Entities.Order", "Orders")
                        .WithMany()
                        .HasForeignKey("OrdersId");

                    b.HasOne("WebApi.Entities.Users", "Users")
                        .WithMany("Carts")
                        .HasForeignKey("UsersId");

                    b.Navigation("Dish");

                    b.Navigation("Orders");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("WebApi.Entities.Order", b =>
                {
                    b.HasOne("WebApi.Entities.Dish", "Dish")
                        .WithMany("Orders")
                        .HasForeignKey("DishId");

                    b.HasOne("WebApi.Entities.Users", "Users")
                        .WithMany("Orders")
                        .HasForeignKey("UsersId");

                    b.Navigation("Dish");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("WebApi.Entities.Dish", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("WebApi.Entities.Users", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
