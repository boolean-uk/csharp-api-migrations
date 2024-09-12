using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exercise.pizzashopapi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "id", "name" },
                values: new object[] { 3, "Julia" });

            migrationBuilder.InsertData(
                table: "pizzas",
                columns: new[] { "id", "name", "price" },
                values: new object[] { 3, "Pepperoni", 15m });

            migrationBuilder.InsertData(
                table: "order",
                columns: new[] { "id", "customer_id", "pizza_id" },
                values: new object[] { 3, 3, 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "order",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
