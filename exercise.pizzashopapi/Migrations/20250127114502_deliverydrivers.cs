using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace exercise.pizzashopapi.Migrations
{
    /// <inheritdoc />
    public partial class deliverydrivers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeliveryDriverId",
                table: "orders",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "delivery_drivers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_delivery_drivers", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orders_DeliveryDriverId",
                table: "orders",
                column: "DeliveryDriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_delivery_drivers_DeliveryDriverId",
                table: "orders",
                column: "DeliveryDriverId",
                principalTable: "delivery_drivers",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_delivery_drivers_DeliveryDriverId",
                table: "orders");

            migrationBuilder.DropTable(
                name: "delivery_drivers");

            migrationBuilder.DropIndex(
                name: "IX_orders_DeliveryDriverId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "DeliveryDriverId",
                table: "orders");
        }
    }
}
