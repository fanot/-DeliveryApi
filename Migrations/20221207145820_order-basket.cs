using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class orderbasket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DishId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Dish_DishId",
                        column: x => x.DishId,
                        principalTable: "Dish",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DishId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TotalPrice = table.Column<double>(type: "float", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    OrdersId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cart_Dish_DishId",
                        column: x => x.DishId,
                        principalTable: "Dish",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cart_Order_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Order",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cart_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_DishId",
                table: "Cart",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_OrdersId",
                table: "Cart",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UsersId",
                table: "Cart",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_DishId",
                table: "Order",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UsersId",
                table: "Order",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
