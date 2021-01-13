using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intelligent_Retail3.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WXUserOrderID",
                table: "WXUserOrder",
                newName: "WXUserID");

            migrationBuilder.RenameColumn(
                name: "WXProductNumber",
                table: "WXUserOrder",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "WXProductID",
                table: "WXUserOrder",
                newName: "WXPayNumber");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "WXUserOrder",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "WXUserOrder",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "WXUserOrder");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "WXUserOrder");

            migrationBuilder.RenameColumn(
                name: "WXUserID",
                table: "WXUserOrder",
                newName: "WXUserOrderID");

            migrationBuilder.RenameColumn(
                name: "WXPayNumber",
                table: "WXUserOrder",
                newName: "WXProductID");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "WXUserOrder",
                newName: "WXProductNumber");
        }
    }
}
