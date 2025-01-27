using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exercise.pizzashopapi.Migrations
{
    /// <inheritdoc />
    public partial class addedStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PizzaStatus",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PizzaStatus", "Status" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PizzaStatus", "Status" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PizzaStatus", "Status" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PizzaStatus", "Status" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PizzaStatus", "Status" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PizzaStatus", "Status" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "PizzaStatus", "Status" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PizzaStatus", "Status" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PizzaStatus", "Status" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "PizzaStatus", "Status" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "PizzaStatus", "Status" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "PizzaStatus", "Status" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "PizzaStatus", "Status" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "PizzaStatus", "Status" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "PizzaStatus", "Status" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "PizzaStatus", "Status" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "PizzaStatus", "Status" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "PizzaStatus", "Status" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "PizzaStatus", "Status" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "PizzaStatus", "Status" },
                values: new object[] { 2, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PizzaStatus",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");
        }
    }
}
