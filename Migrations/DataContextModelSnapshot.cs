﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Helpers;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    b.HasData(
                        new
                        {
                            Id = "31101a8b-b9fa-4dbe-85c5-c6ca745046665",
                            Category = 0,
                            Description = "Лапша пшеничная, креветки, кальмар, шампиньоны, лук красный, заправка Том Ям (паста Том Ям, паста Том Кха, сахар, соевый соус), сливки, соевый соус, помидор, перец чили. БЖУ на 100 г. Белки, г - 8,57 Жиры, г - 12,8 Углеводы, г - 18,8",
                            Image = "https://mistertako.ru/uploads/products/bacd88ca-54ed-11ed-8575-0050569dbef0.jpg",
                            Name = "Wok том ям с морепродуктам",
                            Price = 340.0,
                            Rating = 5.0,
                            Vegetarian = false
                        },
                        new
                        {
                            Id = "31101a8b-b9fa-4dbe-85c5-c6ca745064655",
                            Category = 0,
                            Description = "Лапша пшеничная, шампиньоны, лук красный, заправка Том Ям (паста Том Ям, паста Том Кха, сахар, соевый соус), сливки, соевый соус, помидор, перец чили. БЖУ на 100 г. Белки, г - 5,32 Жиры, г - 14,89 Углеводы, г - 22,46",
                            Image = "https://mistertako.ru/uploads/products/cd661716-54ed-11ed-8575-0050569dbef0.jpg",
                            Name = "Wok том ям с овощами",
                            Price = 250.0,
                            Rating = 9.0,
                            Vegetarian = true
                        },
                        new
                        {
                            Id = "31101a8b-b9fa-4dbe-85c5-c6ca745604255",
                            Category = 0,
                            Description = "Копченая куриная грудка, свежие шампиньоны, маринованные опята, сыр «Моцарелла», сыр «Гауда», сливочно-чесночный соус, свежая зелень.",
                            Image = "https://mistertako.ru/uploads/products/cd661716-54ed-11ed-8575-0050569dbef0.jpg",
                            Name = "Белиссимо",
                            Price = 250.0,
                            Rating = 9.0,
                            Vegetarian = true
                        },
                        new
                        {
                            Id = "31101a8b-b9fa-4dbe-85c5-c6ca746204655",
                            Category = 4,
                            Description = "Классический молочный коктейль",
                            Image = "https://mistertako.ru/uploads/products/120b46bc-5f32-11e8-8f7d-00155dd9fd01.jpg",
                            Name = "Коктейль классический",
                            Price = 140.0,
                            Rating = 5.6666666599999997,
                            Vegetarian = true
                        },
                        new
                        {
                            Id = "31101a8b-b9fa-4dbe-85c5-c6ca742664655",
                            Category = 4,
                            Description = "Классический молочный коктейль с клубничным топпингом",
                            Image = "https://mistertako.ru/uploads/products/120b46bd-5f32-11e8-8f7d-00155dd9fd01.jpg",
                            Name = "Коктейль клубничный",
                            Price = 170.0,
                            Rating = 7.7649999999999997,
                            Vegetarian = true
                        },
                        new
                        {
                            Id = "31101a8b-b9fa-4dbe-85c5-c6ca7426664655",
                            Category = 4,
                            Description = "Классический молочный коктейль с добавлением шоколадного топпинга",
                            Image = "https://mistertako.ru/uploads/products/120b46be-5f32-11e8-8f7d-00155dd9fd01.jpg",
                            Name = "Коктейль шоколадный",
                            Price = 170.0,
                            Rating = 1.75,
                            Vegetarian = true
                        },
                        new
                        {
                            Id = "31101a8b-b9fa-4dbe-85c5-c6ca7426664055",
                            Category = 4,
                            Description = "Смородиновый морс",
                            Image = "https://mistertako.ru/uploads/products/120b46c1-5f32-11e8-8f7d-00155dd9fd01.jpg",
                            Name = "Морс cмородиновый",
                            Price = 90.0,
                            Rating = 8.0,
                            Vegetarian = true
                        },
                        new
                        {
                            Id = "31101a8b-b9fa-4dbe-85c5-c6ca7462668055",
                            Category = 4,
                            Description = "Облепиха, имбирь, сахар",
                            Image = "https://mistertako.ru/uploads/products/5a7d58a5-879d-11eb-850a-0050569dbef0.jpg",
                            Name = "Морс облепиховый",
                            Price = 90.0,
                            Rating = 6.0625,
                            Vegetarian = true
                        },
                        new
                        {
                            Id = "31101a8b-b9fa-4dbe-85c5-c6ca7326668055",
                            Category = 2,
                            Description = "Сырный бульон с пшеничной лапшой, отварным куриным филе,помидором и сырными шариками. БЖУ на 100 г. Белки, г — 11,8 Жиры, г — 9,82 Углеводы, г — 22,69",
                            Image = "https://mistertako.ru/uploads/products/ccd8e2de-5f36-11e8-8f7d-00155dd9fd01.jpg",
                            Name = "Рамен сырный",
                            Price = 300.0,
                            Rating = 3.0,
                            Vegetarian = false
                        },
                        new
                        {
                            Id = "31101a8b-b9fa-4dbe-85c5-c6ca7326660055",
                            Category = 3,
                            Description = "Апельсин, банан, шоколадная крошка, сыр творожный, сырная лепешка. БЖУ на 100 г. Белки, г - 5,86 Жиры, г - 13,12 Углеводы, г - 44,05",
                            Image = "https://mistertako.ru/uploads/products/05391255-54ee-11ed-8575-0050569dbef0.jpg",
                            Name = "Сладкий ролл с апельсином и бананом",
                            Price = 250.0,
                            Rating = 5.0,
                            Vegetarian = true
                        },
                        new
                        {
                            Id = "31101a8b-b9fa-4dbe-85c5-c6ca7326606055",
                            Category = 3,
                            Description = "Апельсин, банан, шоколадная крошка, сыр творожный, сырная лепешка. БЖУ на 100 г. Белки, г - 5,86 Жиры, г - 13,12 Углеводы, г - 44,05",
                            Image = "https://mistertako.ru/uploads/products/05391255-54ee-11ed-8575-0050569dbef0.jpg",
                            Name = "Сладкий ролл с апельсином и бананом",
                            Price = 250.0,
                            Rating = 5.0,
                            Vegetarian = true
                        },
                        new
                        {
                            Id = "31101a8b-b9fa-4dbe-85c5-c6ca7226660055",
                            Category = 3,
                            Description = "Сырная лепешка, банан, арахис, сливочный сыр, шоколадная крошка, топинг карамельный",
                            Image = "https://mistertako.ru/uploads/products/a4772f7a-7a6f-11eb-850a-0050569dbef0.jpeg",
                            Name = "Сладкий ролл с арахисом и бананом",
                            Price = 210.0,
                            Rating = 7.625,
                            Vegetarian = true
                        },
                        new
                        {
                            Id = "31101a8b-b9fa-4dbe-85c5-c6ca73267055",
                            Category = 3,
                            Description = "Сырная лепешка, банан, киви, сливочный сыр, топинг клубничный",
                            Image = "https://mistertako.ru/uploads/products/9e7c8581-7a6f-11eb-850a-0050569dbef0.jpeg",
                            Name = "Сладкий ролл с бананом и киви",
                            Price = 220.0,
                            Rating = 5.5,
                            Vegetarian = true
                        },
                        new
                        {
                            Id = "31101a8b-b9fa-4dbe-85c5-c6ca732675555",
                            Category = 3,
                            Description = "Чизкейк Нью-Йорк - настоящая классика. Его основа - сочетание вкусов нежнейшего сливочного сыра и тонкой песочной корочки.",
                            Image = "https://mistertako.ru/uploads/products/120b46b1-5f32-11e8-8f7d-00155dd9fd01.jpg",
                            Name = "Чизкейк Нью-Йорк",
                            Price = 210.0,
                            Rating = 9.25,
                            Vegetarian = true
                        },
                        new
                        {
                            Id = "31101a8b-b9fa-4dbe-85c5-c6ca732655555",
                            Category = 2,
                            Description = "Знаменитый тайский острый суп со сливками, куриным филе, шампиньонами, красным луком, помидором, перчиком Чили и кинзой. Подается с рисом. БЖУ на 100 г. Белки, г — 5,75 Жиры, г — 3,72 Углеводы, г — 14,76",
                            Image = "https://mistertako.ru/uploads/products/ccd8e2de-5f36-11e8-8f7d-00155dd9fd01.jpg",
                            Name = "Том ям кай",
                            Price = 300.0,
                            Rating = 2.3333300000000001,
                            Vegetarian = false
                        },
                        new
                        {
                            Id = "31101a8b-b9fa-4dbe-85c5-c6ca032655555",
                            Category = 2,
                            Description = "Бульон рамен со сливками (куриный бульон, чесночно-имбирная заправка, соевый соус) с пшеничной лапшой, отварной курицей, омлетом Томаго и шампиньонами. БЖУ на 100 г. Белки, г — 8,13 Жиры, г — 6,18 Углеводы, г — 8,08",
                            Image = "https://mistertako.ru/uploads/products/ccd8e2de-5f36-11e8-8f7d-00155dd9fd01.jpg",
                            Name = "Сливочный рамен с курицей и шампиньонами",
                            Price = 260.0,
                            Rating = 2.3333300000000001,
                            Vegetarian = false
                        });
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

            modelBuilder.Entity("WebApi.Entities.RatingScore", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DishId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RatingScore");
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

                    b.HasData(
                        new
                        {
                            Id = "31101a8b-b9fa-4dbe-85c5-c6ca7465046r5",
                            Address = "grow stret 1",
                            BirthDate = new DateTime(2022, 12, 14, 11, 44, 28, 362, DateTimeKind.Utc).AddTicks(3439),
                            Email = "uswe@sgrg.com",
                            FullName = "TEST Name",
                            Gender = 0,
                            PhoneNumber = "34545654656"
                        },
                        new
                        {
                            Id = "31101a8b-b9fa-4dbe-85c5-c6ca745046666",
                            Address = "grow stret 2",
                            BirthDate = new DateTime(2022, 12, 14, 11, 44, 28, 362, DateTimeKind.Utc).AddTicks(3445),
                            Email = "12uswe@sgrg.com",
                            FullName = "TEST Name",
                            Gender = 1,
                            PhoneNumber = "34545654656"
                        });
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

            modelBuilder.Entity("WebApi.Entities.RatingScore", b =>
                {
                    b.HasOne("WebApi.Entities.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UserId");

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
