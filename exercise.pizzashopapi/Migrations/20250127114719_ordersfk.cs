using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exercise.pizzashopapi.Migrations
{
    /// <inheritdoc />
    public partial class ordersfk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_delivery_drivers_DeliveryDriverId",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "DeliveryDriverId",
                table: "orders",
                newName: "delivery_driver_id");

            migrationBuilder.RenameIndex(
                name: "IX_orders_DeliveryDriverId",
                table: "orders",
                newName: "IX_orders_delivery_driver_id");

            migrationBuilder.AlterColumn<int>(
                name: "delivery_driver_id",
                table: "orders",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_delivery_drivers_delivery_driver_id",
                table: "orders",
                column: "delivery_driver_id",
                principalTable: "delivery_drivers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_delivery_drivers_delivery_driver_id",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "delivery_driver_id",
                table: "orders",
                newName: "DeliveryDriverId");

            migrationBuilder.RenameIndex(
                name: "IX_orders_delivery_driver_id",
                table: "orders",
                newName: "IX_orders_DeliveryDriverId");

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryDriverId",
                table: "orders",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_delivery_drivers_DeliveryDriverId",
                table: "orders",
                column: "DeliveryDriverId",
                principalTable: "delivery_drivers",
                principalColumn: "id");
        }
    }
}
