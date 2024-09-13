using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exercise.pizzashopapi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "order",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "order",
                keyColumn: "id",
                keyValue: 1,
                column: "status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "order",
                keyColumn: "id",
                keyValue: 2,
                column: "status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "order",
                keyColumn: "id",
                keyValue: 3,
                column: "status",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "order");
        }
    }
}
