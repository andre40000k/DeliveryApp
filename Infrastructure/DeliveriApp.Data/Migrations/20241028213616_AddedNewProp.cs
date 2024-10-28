using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveriApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TimeDelivery",
                table: "Order",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TimeDelivery",
                table: "FiltrationOrder",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeDelivery",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "TimeDelivery",
                table: "FiltrationOrder");
        }
    }
}
