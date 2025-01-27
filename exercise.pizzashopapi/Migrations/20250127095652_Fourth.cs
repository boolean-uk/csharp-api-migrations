using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace exercise.pizzashopapi.Migrations
{
    /// <inheritdoc />
    public partial class Fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "CustomerId", "PizzaId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumns: new[] { "CustomerId", "PizzaId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumns: new[] { "CustomerId", "PizzaId" },
                keyValues: new object[] { 2, 1 });
        }
    }
}
