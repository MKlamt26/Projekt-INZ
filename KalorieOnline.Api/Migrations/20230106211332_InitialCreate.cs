using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KalorieOnline.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sets = table.Column<int>(type: "int", nullable: false),
                    Repetitions = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calories = table.Column<double>(type: "float", nullable: false),
                    Carbo = table.Column<double>(type: "float", nullable: false),
                    Protein = table.Column<double>(type: "float", nullable: false),
                    Fat = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TreningCartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    Sets = table.Column<int>(type: "int", nullable: false),
                    Repetitions = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreningCartItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TreningCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreningCarts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "userDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Activity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Goal = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ExerciseCategory",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Weight training" },
                    { 2, "Own bodyweight training" }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Repetitions", "Sets" },
                values: new object[,]
                {
                    { 1, 1, "The deadlift is a multi-joint exercise involving multiple muscle groups", "deadlift", 1, 1 },
                    { 2, 1, "An exercise involving the gluteal muscles as well as the muscles of the thighs and calves", "squats", 1, 1 },
                    { 3, 2, "Pushups are an exercise in which a person, keeping a prone position, with the hands palms down under the shoulders, the balls of the feet on the ground, and the back straight, pushes the body up and lets it down by an alternate straightening and bending of the arms.", "push-ups", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "High_Fat" },
                    { 2, "High_Carbo" },
                    { 3, "High_protein" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Calories", "Carbo", "CategoryId", "Description", "Fat", "ImageURL", "Name", "Protein" },
                values: new object[,]
                {
                    { 1, 7.3499999999999996, 0.0070000000000000001, 1, "Butter has a lot of saturated fat, limit its consumption", 0.82499999999999996, "/Images/HighFat/Butter.jpg", "Butter", 0.0070000000000000001 },
                    { 2, 3.5699999999999998, 0.87, 2, "Pasta contains a lot of carbohydrates", 0.021000000000000001, "/Images/HighCarbohydrates/Pasta.jpg", "Pasta", 0.044999999999999998 },
                    { 3, 2.9700000000000002, 0.56699999999999995, 2, "Roll has a lot of carbohydrates", 0.035999999999999997, "/Images/HighCarbohydrates/Roll.jpg", "Roll", 0.091999999999999998 },
                    { 4, 0.97999999999999998, 0.0, 3, "Chicken breast is high in protein and low in fat", 0.012999999999999999, "/Images/HighProtein/ChickenBreast.jpg", "Chicken breast", 0.215 }
                });

            migrationBuilder.InsertData(
                table: "TreningCarts",
                columns: new[] { "Id", "CreatedDate", "UserId" },
                values: new object[] { 1, new DateTime(2023, 1, 7, 22, 13, 32, 334, DateTimeKind.Local).AddTicks(8073), 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "UserName", "UserPassword" },
                values: new object[,]
                {
                    { 1, "michal", "123" },
                    { 2, "natalia", "321" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "ExerciseCategory");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "TreningCartItems");

            migrationBuilder.DropTable(
                name: "TreningCarts");

            migrationBuilder.DropTable(
                name: "userDatas");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
