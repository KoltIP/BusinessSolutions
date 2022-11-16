using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessSolutions.Data.Context.Migrations
{
    /// <inheritdoc />
    public partial class FixUniqueProb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_providers_Name",
                table: "providers");

            migrationBuilder.DropIndex(
                name: "IX_orders_Number",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orderitems_Name",
                table: "orderitems");

            migrationBuilder.DropIndex(
                name: "IX_orderitems_Quantity",
                table: "orderitems");

            migrationBuilder.DropIndex(
                name: "IX_orderitems_Unit",
                table: "orderitems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_providers_Name",
                table: "providers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_orders_Number",
                table: "orders",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_orderitems_Name",
                table: "orderitems",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_orderitems_Quantity",
                table: "orderitems",
                column: "Quantity",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_orderitems_Unit",
                table: "orderitems",
                column: "Unit",
                unique: true);
        }
    }
}
