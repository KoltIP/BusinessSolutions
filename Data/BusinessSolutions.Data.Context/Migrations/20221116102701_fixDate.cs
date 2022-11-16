using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessSolutions.Data.Context.Migrations
{
    /// <inheritdoc />
    public partial class fixDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_orders_Date",
                table: "orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_orders_Date",
                table: "orders",
                column: "Date",
                unique: true);
        }
    }
}
