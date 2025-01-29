using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exercise.pizzashopapi.Migrations
{
    /// <inheritdoc />
    public partial class TableNameUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Pizzas_PizzaId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderToppings_Orders_OrderId",
                table: "OrderToppings");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderToppings_Toppings_ToppingId",
                table: "OrderToppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Toppings",
                table: "Toppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pizzas",
                table: "Pizzas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderToppings",
                table: "OrderToppings");

            migrationBuilder.RenameTable(
                name: "Toppings",
                newName: "toppings");

            migrationBuilder.RenameTable(
                name: "Pizzas",
                newName: "pizzas");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "orders");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "customers");

            migrationBuilder.RenameTable(
                name: "OrderToppings",
                newName: "order_toppings");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_PizzaId",
                table: "orders",
                newName: "IX_orders_PizzaId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerId",
                table: "orders",
                newName: "IX_orders_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderToppings_ToppingId",
                table: "order_toppings",
                newName: "IX_order_toppings_ToppingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_toppings",
                table: "toppings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pizzas",
                table: "pizzas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orders",
                table: "orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_customers",
                table: "customers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_order_toppings",
                table: "order_toppings",
                columns: new[] { "OrderId", "ToppingId" });

            migrationBuilder.AddForeignKey(
                name: "FK_order_toppings_orders_OrderId",
                table: "order_toppings",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_toppings_toppings_ToppingId",
                table: "order_toppings",
                column: "ToppingId",
                principalTable: "toppings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_customers_CustomerId",
                table: "orders",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_pizzas_PizzaId",
                table: "orders",
                column: "PizzaId",
                principalTable: "pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_toppings_orders_OrderId",
                table: "order_toppings");

            migrationBuilder.DropForeignKey(
                name: "FK_order_toppings_toppings_ToppingId",
                table: "order_toppings");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_customers_CustomerId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_pizzas_PizzaId",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_toppings",
                table: "toppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pizzas",
                table: "pizzas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orders",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_customers",
                table: "customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_order_toppings",
                table: "order_toppings");

            migrationBuilder.RenameTable(
                name: "toppings",
                newName: "Toppings");

            migrationBuilder.RenameTable(
                name: "pizzas",
                newName: "Pizzas");

            migrationBuilder.RenameTable(
                name: "orders",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "customers",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "order_toppings",
                newName: "OrderToppings");

            migrationBuilder.RenameIndex(
                name: "IX_orders_PizzaId",
                table: "Orders",
                newName: "IX_Orders_PizzaId");

            migrationBuilder.RenameIndex(
                name: "IX_orders_CustomerId",
                table: "Orders",
                newName: "IX_Orders_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_order_toppings_ToppingId",
                table: "OrderToppings",
                newName: "IX_OrderToppings_ToppingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Toppings",
                table: "Toppings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pizzas",
                table: "Pizzas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderToppings",
                table: "OrderToppings",
                columns: new[] { "OrderId", "ToppingId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Pizzas_PizzaId",
                table: "Orders",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderToppings_Orders_OrderId",
                table: "OrderToppings",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderToppings_Toppings_ToppingId",
                table: "OrderToppings",
                column: "ToppingId",
                principalTable: "Toppings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
