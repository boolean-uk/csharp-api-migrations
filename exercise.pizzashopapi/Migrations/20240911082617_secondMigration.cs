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
            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 1,
                column: "price",
                value: 8m);

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 2,
                column: "price",
                value: 2m);

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 3,
                column: "price",
                value: 5m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 1,
                column: "price",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 2,
                column: "price",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 3,
                column: "price",
                value: 0m);
        }
    }
}
