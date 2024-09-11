using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace exercise.pizzashopapi.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    customer_id = table.Column<int>(type: "integer", nullable: false),
                    pizza_id = table.Column<int>(type: "integer", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Time_since_ordered = table.Column<double>(type: "double precision", nullable: false),
                    TimeOrdered = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => new { x.customer_id, x.pizza_id });
                });

            migrationBuilder.CreateTable(
                name: "pizzas",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pizzas", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "customer",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Nigel" },
                    { 2, "Dave" },
                    { 3, "Felix" }
                });

            migrationBuilder.InsertData(
                table: "orders",
                columns: new[] { "customer_id", "pizza_id", "id", "Status", "TimeOrdered", "Time_since_ordered" },
                values: new object[,]
                {
                    { 1, 1, 1, "Preparing pizza", new DateTime(2024, 9, 11, 11, 58, 11, 115, DateTimeKind.Utc).AddTicks(4564), 0.0 },
                    { 2, 2, 2, "Preparing pizza", new DateTime(2024, 9, 11, 11, 58, 11, 115, DateTimeKind.Utc).AddTicks(4656), 0.0 },
                    { 3, 3, 3, "Preparing pizza", new DateTime(2024, 9, 11, 11, 58, 11, 115, DateTimeKind.Utc).AddTicks(4661), 0.0 }
                });

            migrationBuilder.InsertData(
                table: "pizzas",
                columns: new[] { "id", "name", "price" },
                values: new object[,]
                {
                    { 1, "Cheese & Pineapple", 8m },
                    { 2, "Vegan Cheese Tastic", 2m },
                    { 3, "Kebab & Pommes Frites", 5m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "pizzas");
        }
    }
}
