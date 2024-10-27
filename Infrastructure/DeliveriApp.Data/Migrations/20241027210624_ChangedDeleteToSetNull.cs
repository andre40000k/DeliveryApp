using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveriApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedDeleteToSetNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Region_RegionId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Region_City_CityId",
                table: "Region");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Region_RegionId",
                table: "Order",
                column: "RegionId",
                principalTable: "Region",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Region_City_CityId",
                table: "Region",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Region_RegionId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Region_City_CityId",
                table: "Region");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Region_RegionId",
                table: "Order",
                column: "RegionId",
                principalTable: "Region",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Region_City_CityId",
                table: "Region",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id");
        }
    }
}
