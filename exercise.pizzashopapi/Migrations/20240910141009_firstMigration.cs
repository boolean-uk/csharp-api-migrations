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
                name: "customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.id);
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

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    customerId = table.Column<int>(type: "integer", nullable: false),
                    pizzaId = table.Column<int>(type: "integer", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => new { x.customerId, x.pizzaId });
                    table.ForeignKey(
                        name: "FK_orders_customers_customerId",
                        column: x => x.customerId,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_pizzas_pizzaId",
                        column: x => x.pizzaId,
                        principalTable: "pizzas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Sandy Kong" },
                    { 2, "Knuckles Daisy" },
                    { 3, "Spongebob Peach" },
                    { 4, "Knuckles the Hedgehog" },
                    { 5, "Luigi Mario" },
                    { 6, "Patrick the Echidna" },
                    { 7, "Princess Star" },
                    { 8, "Patrick Kong" },
                    { 9, "Spongebob the Dinosaur" }
                });

            migrationBuilder.InsertData(
                table: "pizzas",
                columns: new[] { "id", "name", "price" },
                values: new object[,]
                {
                    { 1, "Grass & Sardine", 11m },
                    { 2, "Cheese & Sardine", 14m },
                    { 3, "Mold & Ketchup", 8m },
                    { 4, "Cheese & Despair", 9m },
                    { 5, "Tomato & Expired Milk", 17m },
                    { 6, "Candy & Cheese", 12m },
                    { 7, "Mold & California Reaper", 13m },
                    { 8, "Dirt & Ketchup", 13m },
                    { 9, "Depression & Ketchup", 12m }
                });

            migrationBuilder.InsertData(
                table: "orders",
                columns: new[] { "customerId", "pizzaId", "id" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 5 },
                    { 6, 6, 6 },
                    { 7, 7, 7 },
                    { 8, 8, 8 },
                    { 9, 9, 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_orders_pizzaId",
                table: "orders",
                column: "pizzaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "pizzas");
        }
    }
}
