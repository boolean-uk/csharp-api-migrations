using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exercise.pizzashopapi.Migrations
{
    /// <inheritdoc />
    public partial class Fifth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "customer",
                columns: new[] { "id", "name" },
                values: new object[] { 8, "Håkon" });

            migrationBuilder.InsertData(
                table: "pizza",
                columns: new[] { "id", "name", "price" },
                values: new object[] { 9, "Meatlover", 12.99m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "customer",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "pizza",
                keyColumn: "id",
                keyValue: 9);
        }
    }
}
