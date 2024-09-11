using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exercise.pizzashopapi.Migrations
{
    /// <inheritdoc />
    public partial class fourthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "orderStatus",
                table: "orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "timeLeft",
                table: "orders",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 1,
                column: "name",
                value: "Luigi the Hedgehog");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 2,
                column: "name",
                value: "Sonic the Dinosaur");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 3,
                column: "name",
                value: "Patrick the Dinosaur");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 4,
                column: "name",
                value: "Sonic Star");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 5,
                column: "name",
                value: "Donkey Mario");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 6,
                column: "name",
                value: "Sonic Daisy");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 7,
                column: "name",
                value: "Yoshi the Dinosaur");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 8,
                column: "name",
                value: "Luigi Star");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 9,
                column: "name",
                value: "Princess Star");

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumns: new[] { "customerId", "pizzaId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "orderStatus", "timeLeft" },
                values: new object[] { 1, new TimeSpan(0, 0, 4, 11, 0) });

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumns: new[] { "customerId", "pizzaId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "orderStatus", "timeLeft" },
                values: new object[] { 0, new TimeSpan(0, 0, 1, 27, 0) });

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumns: new[] { "customerId", "pizzaId" },
                keyValues: new object[] { 3, 3 },
                columns: new[] { "orderStatus", "timeLeft" },
                values: new object[] { 0, new TimeSpan(0, 0, 0, 8, 0) });

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumns: new[] { "customerId", "pizzaId" },
                keyValues: new object[] { 4, 4 },
                columns: new[] { "orderStatus", "timeLeft" },
                values: new object[] { 1, new TimeSpan(0, 0, 2, 42, 0) });

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumns: new[] { "customerId", "pizzaId" },
                keyValues: new object[] { 5, 5 },
                columns: new[] { "orderStatus", "timeLeft" },
                values: new object[] { 1, new TimeSpan(0, 0, 10, 1, 0) });

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumns: new[] { "customerId", "pizzaId" },
                keyValues: new object[] { 6, 6 },
                columns: new[] { "orderStatus", "timeLeft" },
                values: new object[] { 1, new TimeSpan(0, 0, 8, 38, 0) });

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumns: new[] { "customerId", "pizzaId" },
                keyValues: new object[] { 7, 7 },
                columns: new[] { "orderStatus", "timeLeft" },
                values: new object[] { 0, new TimeSpan(0, 0, 1, 1, 0) });

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumns: new[] { "customerId", "pizzaId" },
                keyValues: new object[] { 8, 8 },
                columns: new[] { "orderStatus", "timeLeft" },
                values: new object[] { 1, new TimeSpan(0, 0, 5, 9, 0) });

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumns: new[] { "customerId", "pizzaId" },
                keyValues: new object[] { 9, 9 },
                columns: new[] { "orderStatus", "timeLeft" },
                values: new object[] { 1, new TimeSpan(0, 0, 8, 56, 0) });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "name", "price" },
                values: new object[] { "Grass & California Reaper Pizza", 10m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "name", "price" },
                values: new object[] { "Mold & Despair Pizza", 11m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "name", "price" },
                values: new object[] { "Mold & Despair Pizza", 18m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "name", "price" },
                values: new object[] { "Tomato & Ketchup Pizza", 19m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "name", "price" },
                values: new object[] { "Dirt & Cheese Pizza", 10m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "name", "price" },
                values: new object[] { "Depression & Ketchup Pizza", 16m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "name", "price" },
                values: new object[] { "Mold & California Reaper Pizza", 19m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "name", "price" },
                values: new object[] { "Grass & Cheese Pizza", 16m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "name", "price" },
                values: new object[] { "Depression & Expired Milk Pizza", 17m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "orderStatus",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "timeLeft",
                table: "orders");

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
    }
}
