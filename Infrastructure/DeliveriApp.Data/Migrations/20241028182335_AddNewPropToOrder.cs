using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveriApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewPropToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Distance",
                table: "Order",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeOrder",
                table: "Order",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Distance",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "TimeOrder",
                table: "Order");
        }
    }
}
