using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace exercise.pizzashopapi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
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
                    Name = table.Column<string>(type: "text", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
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
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PizzaId = table.Column<int>(type: "integer", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Orders_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name", "OrderId" },
                values: new object[,]
                {
                    { 1, "Nigel", 0 },
                    { 2, "Dave", 0 },
                    { 3, "Alice", 0 },
                    { 4, "Bob", 0 },
                    { 5, "Charlie", 0 },
                    { 6, "Diana", 0 },
                    { 7, "Edward", 0 },
                    { 8, "Fiona", 0 },
                    { 9, "George", 0 },
                    { 10, "Hannah", 0 }
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Name", "OrderId", "Price" },
                values: new object[,]
                {
                    { 1, "Cheese & Pineapple", 0, 393m },
                    { 2, "Vegan Cheese Tastic", 0, 498m },
                    { 3, "Pepperoni Feast", 0, 227m },
                    { 4, "BBQ Chicken Delight", 0, 398m },
                    { 5, "Margarita Supreme", 0, 272m },
                    { 6, "Four Seasons", 0, 376m },
                    { 7, "Meat Lover's Special", 0, 378m },
                    { 8, "Spicy Veggie", 0, 196m },
                    { 9, "Garlic Mushroom", 0, 156m },
                    { 10, "Buffalo Ranch", 0, 140m }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "PizzaId" },
                values: new object[,]
                {
                    { 1, 7, 6 },
                    { 2, 3, 8 },
                    { 3, 2, 8 },
                    { 4, 1, 2 },
                    { 5, 3, 8 },
                    { 6, 8, 3 },
                    { 7, 2, 6 },
                    { 8, 5, 4 },
                    { 9, 2, 2 },
                    { 10, 5, 1 },
                    { 11, 4, 3 },
                    { 12, 10, 6 },
                    { 13, 6, 4 },
                    { 14, 7, 9 },
                    { 15, 6, 9 },
                    { 16, 3, 4 },
                    { 17, 10, 2 },
                    { 18, 2, 9 },
                    { 19, 3, 5 },
                    { 20, 5, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PizzaId",
                table: "Orders",
                column: "PizzaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Pizzas");
        }
    }
}
