using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exercise.pizzashopapi.Migrations
{
    /// <inheritdoc />
    public partial class secondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_orders_pizzaId",
                table: "orders");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 1,
                column: "name",
                value: "Sonic Mario");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 2,
                column: "name",
                value: "Patrick Cheeks");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 3,
                column: "name",
                value: "Knuckles Peach");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 4,
                column: "name",
                value: "Mario the Dinosaur");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 5,
                column: "name",
                value: "Sandy Mario");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 6,
                column: "name",
                value: "Patrick Cheeks");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 7,
                column: "name",
                value: "Sonic Star");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 8,
                column: "name",
                value: "Princess Squarepants");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 9,
                column: "name",
                value: "Knuckles Mario");

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "name", "price" },
                values: new object[] { "Grass & California Reaper", 16m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "name", "price" },
                values: new object[] { "Depression & Despair", 19m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "name", "price" },
                values: new object[] { "Cheese & Cheese", 13m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "name", "price" },
                values: new object[] { "Dirt & Despair", 18m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "name", "price" },
                values: new object[] { "Grass ", 8m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "name", "price" },
                values: new object[] { "Candy & Sardine", 19m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "name", "price" },
                values: new object[] { "Depression & California Reaper", 12m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "name", "price" },
                values: new object[] { "Cheese ", 16m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "name", "price" },
                values: new object[] { "Candy & Sardine", 16m });

            migrationBuilder.CreateIndex(
                name: "IX_orders_customerId",
                table: "orders",
                column: "customerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_orders_pizzaId",
                table: "orders",
                column: "pizzaId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_orders_customerId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_pizzaId",
                table: "orders");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 1,
                column: "name",
                value: "Sandy Kong");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 2,
                column: "name",
                value: "Knuckles Daisy");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 3,
                column: "name",
                value: "Spongebob Peach");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 4,
                column: "name",
                value: "Knuckles the Hedgehog");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 5,
                column: "name",
                value: "Luigi Mario");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 6,
                column: "name",
                value: "Patrick the Echidna");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 7,
                column: "name",
                value: "Princess Star");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 8,
                column: "name",
                value: "Patrick Kong");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 9,
                column: "name",
                value: "Spongebob the Dinosaur");

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "name", "price" },
                values: new object[] { "Grass & Sardine", 11m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "name", "price" },
                values: new object[] { "Cheese & Sardine", 14m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "name", "price" },
                values: new object[] { "Mold & Ketchup", 8m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "name", "price" },
                values: new object[] { "Cheese & Despair", 9m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "name", "price" },
                values: new object[] { "Tomato & Expired Milk", 17m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "name", "price" },
                values: new object[] { "Candy & Cheese", 12m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "name", "price" },
                values: new object[] { "Mold & California Reaper", 13m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "name", "price" },
                values: new object[] { "Dirt & Ketchup", 13m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "name", "price" },
                values: new object[] { "Depression & Ketchup", 12m });

            migrationBuilder.CreateIndex(
                name: "IX_orders_pizzaId",
                table: "orders",
                column: "pizzaId");
        }
    }
}
