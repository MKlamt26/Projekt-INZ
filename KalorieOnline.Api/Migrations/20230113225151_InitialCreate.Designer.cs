﻿// <auto-generated />
using System;
using KalorieOnline.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KalorieOnline.Api.Migrations
{
    [DbContext(typeof(CaloriesOnlineDbContext))]
    [Migration("20230113225151_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("KalorieOnline.Api.Entities.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("KalorieOnline.Api.Entities.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("KalorieOnline.Api.Entities.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Repetitions")
                        .HasColumnType("int");

                    b.Property<int>("Sets")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Exercises");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "The deadlift is a multi-joint exercise involving multiple muscle groups",
                            Name = "deadlift",
                            Repetitions = 1,
                            Sets = 1,
                            Weight = 100
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "An exercise involving the gluteal muscles as well as the muscles of the thighs and calves",
                            Name = "squats",
                            Repetitions = 1,
                            Sets = 1,
                            Weight = 80
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Description = "Pushups are an exercise in which a person, keeping a prone position, with the hands palms down under the shoulders, the balls of the feet on the ground, and the back straight, pushes the body up and lets it down by an alternate straightening and bending of the arms.",
                            Name = "push-ups",
                            Repetitions = 1,
                            Sets = 1,
                            Weight = 0
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Description = "Abdominal crunches are designed to tone the core muscles of the body. The exercise aids in strengthening the core muscles, improving the posture, and increasing the mobility and flexibility of the muscles.",
                            Name = "crunches ",
                            Repetitions = 1,
                            Sets = 1,
                            Weight = 0
                        });
                });

            modelBuilder.Entity("KalorieOnline.Api.Entities.ExerciseCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ExerciseCategory");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Weight training"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Own bodyweight training"
                        });
                });

            modelBuilder.Entity("KalorieOnline.Api.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Calories")
                        .HasColumnType("float");

                    b.Property<double>("Carbo")
                        .HasColumnType("float");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Fat")
                        .HasColumnType("float");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Protein")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Calories = 7.3499999999999996,
                            Carbo = 0.0070000000000000001,
                            CategoryId = 1,
                            Description = "Butter has a lot of saturated fat, limit its consumption",
                            Fat = 0.82499999999999996,
                            ImageURL = "/Images/HighFat/Butter.jpg",
                            Name = "Butter",
                            Protein = 0.0070000000000000001
                        },
                        new
                        {
                            Id = 2,
                            Calories = 3.5699999999999998,
                            Carbo = 0.87,
                            CategoryId = 2,
                            Description = "Pasta contains a lot of carbohydrates",
                            Fat = 0.021000000000000001,
                            ImageURL = "/Images/HighCarbohydrates/Pasta.jpg",
                            Name = "Pasta",
                            Protein = 0.044999999999999998
                        },
                        new
                        {
                            Id = 3,
                            Calories = 2.9700000000000002,
                            Carbo = 0.56699999999999995,
                            CategoryId = 2,
                            Description = "Roll has a lot of carbohydrates",
                            Fat = 0.035999999999999997,
                            ImageURL = "/Images/HighCarbohydrates/Roll.jpg",
                            Name = "Roll",
                            Protein = 0.091999999999999998
                        },
                        new
                        {
                            Id = 4,
                            Calories = 0.97999999999999998,
                            Carbo = 0.0,
                            CategoryId = 3,
                            Description = "Chicken breast is high in protein and low in fat",
                            Fat = 0.012999999999999999,
                            ImageURL = "/Images/HighProtein/ChickenBreast.jpg",
                            Name = "Chicken breast",
                            Protein = 0.215
                        });
                });

            modelBuilder.Entity("KalorieOnline.Api.Entities.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "High_Fat"
                        },
                        new
                        {
                            Id = 2,
                            Name = "High_Carbo"
                        },
                        new
                        {
                            Id = 3,
                            Name = "High_protein"
                        });
                });

            modelBuilder.Entity("KalorieOnline.Api.Entities.TreningCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TreningCarts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 1, 14, 23, 51, 50, 996, DateTimeKind.Local).AddTicks(7696),
                            UserId = 1
                        });
                });

            modelBuilder.Entity("KalorieOnline.Api.Entities.TreningCartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int>("Repetitions")
                        .HasColumnType("int");

                    b.Property<int>("Sets")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TreningCartItems");
                });

            modelBuilder.Entity("KalorieOnline.Api.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UserName = "michal",
                            UserPassword = "123"
                        },
                        new
                        {
                            Id = 2,
                            UserName = "natalia",
                            UserPassword = "321"
                        });
                });

            modelBuilder.Entity("KalorieOnline.Api.Entities.UserData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Activity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Goal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("userDatas");
                });
#pragma warning restore 612, 618
        }
    }
}
