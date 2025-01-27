using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace exercise.pizzashopapi.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pizzas_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Donald Trump" },
                    { 2, "Elvis Presley" },
                    { 3, "Barack Obama" },
                    { 4, "Oprah Winfrey" },
                    { 5, "Jimi Hendrix" },
                    { 6, "Mick Jagger" },
                    { 7, "Kate Winslet" },
                    { 8, "Charles Windsor" },
                    { 9, "Kate Middleton" },
                    { 10, "Audrey Hepburn" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "OrderTime" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2023, 12, 25, 23, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, 3, new DateTime(2023, 12, 26, 23, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, 4, new DateTime(2023, 12, 27, 23, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, 5, new DateTime(2023, 12, 28, 23, 0, 0, 0, DateTimeKind.Utc) },
                    { 5, 6, new DateTime(2023, 12, 29, 23, 0, 0, 0, DateTimeKind.Utc) },
                    { 6, 7, new DateTime(2023, 12, 30, 23, 0, 0, 0, DateTimeKind.Utc) },
                    { 7, 8, new DateTime(2023, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc) },
                    { 8, 9, new DateTime(2024, 1, 1, 23, 0, 0, 0, DateTimeKind.Utc) },
                    { 9, 10, new DateTime(2024, 1, 2, 23, 0, 0, 0, DateTimeKind.Utc) },
                    { 10, 1, new DateTime(2024, 1, 3, 23, 0, 0, 0, DateTimeKind.Utc) },
                    { 11, 2, new DateTime(2024, 1, 4, 23, 0, 0, 0, DateTimeKind.Utc) },
                    { 12, 3, new DateTime(2024, 1, 5, 23, 0, 0, 0, DateTimeKind.Utc) },
                    { 13, 4, new DateTime(2024, 1, 6, 23, 0, 0, 0, DateTimeKind.Utc) },
                    { 14, 5, new DateTime(2024, 1, 7, 23, 0, 0, 0, DateTimeKind.Utc) },
                    { 15, 6, new DateTime(2024, 1, 8, 23, 0, 0, 0, DateTimeKind.Utc) },
                    { 16, 7, new DateTime(2024, 1, 9, 23, 0, 0, 0, DateTimeKind.Utc) },
                    { 17, 8, new DateTime(2024, 1, 10, 23, 0, 0, 0, DateTimeKind.Utc) },
                    { 18, 9, new DateTime(2024, 1, 11, 23, 0, 0, 0, DateTimeKind.Utc) },
                    { 19, 10, new DateTime(2024, 1, 12, 23, 0, 0, 0, DateTimeKind.Utc) },
                    { 20, 1, new DateTime(2024, 1, 13, 23, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Name", "OrderId", "Price" },
                values: new object[,]
                {
                    { 1, "Vegan Cheese Tastic", 2, 50m },
                    { 2, "Pepperoni", 3, 50m },
                    { 3, "Margherita", 4, 50m },
                    { 4, "Hawaiian", 5, 50m },
                    { 5, "Vegetarian", 6, 50m },
                    { 6, "Meat Lovers", 7, 50m },
                    { 7, "BBQ Chicken", 8, 50m },
                    { 8, "Buffalo", 9, 50m },
                    { 9, "Supreme", 10, 50m },
                    { 10, "Cheese & Pineapple", 11, 50m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_OrderId",
                table: "Pizzas",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
