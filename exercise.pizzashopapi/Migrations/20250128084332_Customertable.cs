using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace exercise.pizzashopapi.Migrations
{
    /// <inheritdoc />
    public partial class Customertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderTopping");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderTopping",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "integer", nullable: false),
                    ToppingsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTopping", x => new { x.OrdersId, x.ToppingsId });
                    table.ForeignKey(
                        name: "FK_OrderTopping_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderTopping_Toppings_ToppingsId",
                        column: x => x.ToppingsId,
                        principalTable: "Toppings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderTopping_ToppingsId",
                table: "OrderTopping",
                column: "ToppingsId");
        }
    }
}
