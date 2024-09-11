using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace exercise.pizzashopapi.Migrations
{
    /// <inheritdoc />
    public partial class fifthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 1,
                column: "name",
                value: "Patrick the Dinosaur");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 2,
                column: "name",
                value: "Princess Squarepants");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 3,
                column: "name",
                value: "Princess Mario");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 4,
                column: "name",
                value: "Donkey the Dinosaur");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 5,
                column: "name",
                value: "Luigi Peach");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 6,
                column: "name",
                value: "Spongebob the Hedgehog");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 7,
                column: "name",
                value: "Luigi the Echidna");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 8,
                column: "name",
                value: "Sonic Mario");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 9,
                column: "name",
                value: "Patrick Daisy");

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 10, "Sonic the Hedgehog" },
                    { 11, "Sonic Star" },
                    { 12, "Yoshi Squarepants" },
                    { 13, "Sandy Squarepants" },
                    { 14, "Sonic the Echidna" },
                    { 15, "Yoshi the Hedgehog" }
                });

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumns: new[] { "customerId", "pizzaId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "orderStatus", "timeLeft" },
                values: new object[] { 0, new TimeSpan(0, 0, 0, 14, 0) });

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumns: new[] { "customerId", "pizzaId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "orderStatus", "timeLeft" },
                values: new object[] { 2, new TimeSpan(0, 0, 4, 13, 0) });

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumns: new[] { "customerId", "pizzaId" },
                keyValues: new object[] { 3, 3 },
                column: "timeLeft",
                value: new TimeSpan(0, 0, 1, 0, 0));

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumns: new[] { "customerId", "pizzaId" },
                keyValues: new object[] { 4, 4 },
                columns: new[] { "orderStatus", "timeLeft" },
                values: new object[] { 2, new TimeSpan(0, 0, 7, 4, 0) });

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumns: new[] { "customerId", "pizzaId" },
                keyValues: new object[] { 5, 5 },
                columns: new[] { "orderStatus", "timeLeft" },
                values: new object[] { 0, new TimeSpan(0, 0, 1, 54, 0) });

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumns: new[] { "customerId", "pizzaId" },
                keyValues: new object[] { 6, 6 },
                columns: new[] { "orderStatus", "timeLeft" },
                values: new object[] { 2, new TimeSpan(0, 0, 4, 14, 0) });

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumns: new[] { "customerId", "pizzaId" },
                keyValues: new object[] { 7, 7 },
                columns: new[] { "orderStatus", "timeLeft" },
                values: new object[] { 2, new TimeSpan(0, 0, 8, 55, 0) });

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumns: new[] { "customerId", "pizzaId" },
                keyValues: new object[] { 8, 8 },
                columns: new[] { "orderStatus", "timeLeft" },
                values: new object[] { 2, new TimeSpan(0, 0, 1, 3, 0) });

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumns: new[] { "customerId", "pizzaId" },
                keyValues: new object[] { 9, 9 },
                columns: new[] { "orderStatus", "timeLeft" },
                values: new object[] { 0, new TimeSpan(0, 0, 2, 55, 0) });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "name", "price" },
                values: new object[] { "Dirt & Sardine Pizza", 8m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "name", "price" },
                values: new object[] { "Tomato Pizza", 9m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "name", "price" },
                values: new object[] { "Grass & Sardine Pizza", 14m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "name", "price" },
                values: new object[] { "Tomato & California Reaper Pizza", 16m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "name", "price" },
                values: new object[] { "Cheese & Despair Pizza", 11m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "name", "price" },
                values: new object[] { "Candy Pizza", 15m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 7,
                column: "name",
                value: "Dirt & California Reaper Pizza");

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "name", "price" },
                values: new object[] { "Dirt & Sardine Pizza", 13m });

            migrationBuilder.UpdateData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "name", "price" },
                values: new object[] { "Cheese Pizza", 12m });

            migrationBuilder.InsertData(
                table: "pizzas",
                columns: new[] { "id", "name", "price" },
                values: new object[,]
                {
                    { 10, "Depression & Cheese Pizza", 14m },
                    { 11, "Concrete & Expired Milk Pizza", 9m },
                    { 12, "Mold & Despair Pizza", 14m },
                    { 13, "Mold & Expired Milk Pizza", 15m },
                    { 14, "Cheese & Expired Milk Pizza", 8m },
                    { 15, "Depression & Despair Pizza", 18m }
                });

            migrationBuilder.InsertData(
                table: "orders",
                columns: new[] { "customerId", "pizzaId", "id", "orderStatus", "timeLeft" },
                values: new object[,]
                {
                    { 10, 10, 10, 0, new TimeSpan(0, 0, 0, 31, 0) },
                    { 11, 11, 11, 1, new TimeSpan(0, 0, 0, 38, 0) },
                    { 12, 12, 12, 0, new TimeSpan(0, 0, 1, 7, 0) },
                    { 13, 13, 13, 1, new TimeSpan(0, 0, 5, 8, 0) },
                    { 14, 14, 14, 1, new TimeSpan(0, 0, 8, 12, 0) },
                    { 15, 15, 15, 1, new TimeSpan(0, 0, 6, 1, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "orders",
                keyColumns: new[] { "customerId", "pizzaId" },
                keyValues: new object[] { 10, 10 });

            migrationBuilder.DeleteData(
                table: "orders",
                keyColumns: new[] { "customerId", "pizzaId" },
                keyValues: new object[] { 11, 11 });

            migrationBuilder.DeleteData(
                table: "orders",
                keyColumns: new[] { "customerId", "pizzaId" },
                keyValues: new object[] { 12, 12 });

            migrationBuilder.DeleteData(
                table: "orders",
                keyColumns: new[] { "customerId", "pizzaId" },
                keyValues: new object[] { 13, 13 });

            migrationBuilder.DeleteData(
                table: "orders",
                keyColumns: new[] { "customerId", "pizzaId" },
                keyValues: new object[] { 14, 14 });

            migrationBuilder.DeleteData(
                table: "orders",
                keyColumns: new[] { "customerId", "pizzaId" },
                keyValues: new object[] { 15, 15 });

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "pizzas",
                keyColumn: "id",
                keyValue: 15);

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
                column: "timeLeft",
                value: new TimeSpan(0, 0, 0, 8, 0));

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
                column: "name",
                value: "Mold & California Reaper Pizza");

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
    }
}
