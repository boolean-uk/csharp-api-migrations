using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exercise.pizzashopapi.Migrations
{
    /// <inheritdoc />
    public partial class thirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 1,
                column: "name",
                value: "Princess Peach");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 2,
                column: "name",
                value: "Knuckles Star");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 3,
                column: "name",
                value: "Princess Cheeks");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 4,
                column: "name",
                value: "Luigi Peach");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 5,
                column: "name",
                value: "Sandy Daisy");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 6,
                column: "name",
                value: "Knuckles Peach");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 7,
                column: "name",
                value: "Knuckles Star");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 8,
                column: "name",
                value: "Spongebob Cheeks");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 9,
                column: "name",
                value: "Sandy the Hedgehog");

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "name", "price" },
                values: new object[] { "Grass & Ketchup Pizza", 9m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "name", "price" },
                values: new object[] { "Grass & Ketchup Pizza", 15m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "name", "price" },
                values: new object[] { "Tomato & Expired Milk Pizza", 17m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "name", "price" },
                values: new object[] { "Tomato & California Reaper Pizza", 15m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "name", "price" },
                values: new object[] { "Candy & Cheese Pizza", 11m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "name", "price" },
                values: new object[] { "Mold & Expired Milk Pizza", 9m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "name", "price" },
                values: new object[] { "Cheese & California Reaper Pizza", 18m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "name", "price" },
                values: new object[] { "Tomato & Cheese Pizza", 12m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "name", "price" },
                values: new object[] { "Grass & Expired Milk Pizza", 18m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
